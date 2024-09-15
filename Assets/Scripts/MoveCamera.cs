using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Frog _frog;

    private Vector3 _offset;

    private void FixedUpdate()
    {
        _offset = transform.position - _frog.transform.position;
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(_frog.transform.position.x + _offset.x, transform.position.y, transform.position.z);
    }
}
