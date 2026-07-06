using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedOfMovement;
    [SerializeField] private float _jumpingForce;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void Move(float moveHorizontal)
    {
        Vector2 direction = new Vector2(_speedOfMovement * moveHorizontal, _rigidbody.velocity.y);
        _rigidbody.velocity = direction;
    }

    public void Jump(bool isGrounded)
    {
        if (isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _jumpingForce, ForceMode2D.Impulse);
        }
    }
}