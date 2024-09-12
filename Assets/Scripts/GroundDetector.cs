using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool IsGround { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider is CompositeCollider2D)
        {
            IsGround = true;
        }
    }

    private void OnCollisionExit2D()
    {
        IsGround = false;
    }
}
