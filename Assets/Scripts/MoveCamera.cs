using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Frog _frog;

    private Vector3 _offset;

    private void Update()
    {
        _offset = transform.position - _frog.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _frog.transform.position + _offset;
    }
}
