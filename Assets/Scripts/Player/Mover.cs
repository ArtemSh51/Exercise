using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speedOfMovement;
    [SerializeField] private float _jumpingForce;
    [SerializeField] private float _lengthRay;

    private Rigidbody2D _rigidbody;

    public bool IsButtonPressed { get; private set; }

    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        float moveHorizontal = PressMotionButton();

        transform.position += Vector3.right * moveHorizontal * _speedOfMovement * Time.deltaTime;

        TurnByY(moveHorizontal);
    }

    public void Jump()
    {
        RaycastHit2D hit = GetRay();

        if (hit && hit.collider.TryGetComponent(out Ground _))
        {
            IsGrounded = true;

            if (IsButtonPressed)
            {
                _rigidbody.AddForce(transform.up * _jumpingForce, ForceMode2D.Impulse);

                IsButtonPressed = false;
            }
        }
        else if(hit.collider == null)
        {
            IsGrounded = false;
        }
    }

    public float PressMotionButton()
    {
        return Input.GetAxisRaw(Horizontal);
    }

    public RaycastHit2D GetRay()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, _lengthRay);
    }

    public void PressButtonJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsButtonPressed = true;
        }
    }

    private void TurnByY(float directionMove)
    {
        if (directionMove != 0)
        {
            if (directionMove > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (directionMove < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
