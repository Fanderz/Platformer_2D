using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FrogMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForce = 5f;

    private Frog _frog;
    private Rigidbody2D _rigidbody;

    private float _xScale;

    private void Awake()
    {
        _frog = GetComponent<Frog>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _xScale = transform.localScale.x;
    }

    private void OnEnable()
    {
        _frog.OnFrogMove += Move;
        _frog.OnFrogJump += Jump;
    }

    private void OnDisable()
    {
        _frog.OnFrogMove -= Move;
        _frog.OnFrogJump -= Jump;
    }

    private void Move(float direction)
    {
        if (direction != 0f)
        {
            transform.Translate(_moveSpeed * direction * Time.deltaTime * Vector2.right);
            Rotate(direction);
        }
    }

    private void Rotate(float direction)
    {
        if (direction != 0)
            transform.localScale = new Vector3(direction * _xScale, transform.localScale.y, transform.localScale.z);
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, _jumpForce),ForceMode2D.Impulse);
    }
}
