using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _movementSpeed;

    private float _xScale;
    private float _xStartPosition;
    private Vector3 _velocity;

    private Coroutine _coroutine;

    private void Awake()
    {
        _xScale = transform.localScale.x;
        _xStartPosition = transform.position.x;
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Move());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void Rotate(float direction)
    {
        if (direction != 0)
            transform.localScale = new Vector3(direction * _xScale, transform.localScale.y, transform.localScale.z);
    }

    private IEnumerator Move()
    {
        _velocity = Vector3.left * _movementSpeed;

        while(gameObject.activeSelf)
        {
            if (transform.position.x >= _xStartPosition + _distance)
                _velocity.x = -_movementSpeed;
            else if (transform.position.x <= _xStartPosition - _distance)
                _velocity.x = _movementSpeed;

            Rotate(-_velocity.x);
            transform.position += _velocity * Time.deltaTime;

            yield return null;
        }
    }
}
