using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FruitsSpawner : MonoBehaviour
{
    [SerializeField] private Fruit[] _prefab;
    [SerializeField] private List<Transform> _spawnPoints;
    //[SerializeField] private float _repeatRate;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<Fruit> _pool;
    private Coroutine _coroutine;
    //private WaitForSeconds _wait;

    private bool _isRunning = false;
    private int _spawnPointIndex = 0;

    private void Awake()
    {
        _pool = new ObjectPool<Fruit>(
            createFunc: () => Instantiate(_prefab[Random.Range(0, _prefab.Length)], transform),
            actionOnGet: (fruit) => SpawnObject(fruit),
            actionOnRelease: (fruit) => fruit.Deactivate(),
            actionOnDestroy: (fruit) => Destroy(fruit),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);

        //_wait = new WaitForSeconds(_repeatRate);
    }

    private void OnEnable()
    {
        _isRunning = true;
        _coroutine = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        _isRunning = false;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void OnReleaseFruit(Fruit fruit)
    {
        _pool.Release(fruit);

        //fruit.Eated -= OnReleaseFruit;
    }

    private void SpawnObject(Fruit fruit)
    {
        if (_spawnPointIndex < _poolMaxSize)
        {
            Vector3 startPosition = _spawnPoints[_spawnPointIndex++].position;
            fruit.transform.position = startPosition;
            fruit.Activate();
        }
    }

    private IEnumerator Spawning()
    {
        while (_isRunning)
        {
            if (_pool.CountAll < _poolMaxSize || _pool.CountInactive > 0)
            {
                _pool.Get();
                //fruit.Eated += OnReleaseFruit;
            }

            yield return null;
        }
    }
}
