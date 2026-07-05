using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private float _speedOfMovement;
    [SerializeField] private float _jumpingForce;
    [SerializeField] private float _lengthRay;

    private Rigidbody2D _rigidbody;
    private Inputer _inputer;

    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputer = GetComponent<Inputer>();
    }

    private void OnEnable()
    {
        _inputer.ButtonPressed += Jump;
    }

    private void OnDisable()
    {
        _inputer.ButtonPressed -= Jump;
    }

    public void Move()
    {
        float moveHorizontal = PressMotionButton();

        transform.position += Vector3.right * moveHorizontal * _speedOfMovement * Time.deltaTime;
    }

    public void Jump()
    {
        RaycastHit2D hit = GetRay();

        if (hit && hit.collider.TryGetComponent(out Ground _))
        {
            IsGrounded = true;

            _rigidbody.AddForce(transform.up * _jumpingForce, ForceMode2D.Impulse);
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
}
