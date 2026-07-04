using UnityEngine;

[RequireComponent(typeof(Rigidbody) ,typeof(Animator), typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string IsGo = nameof(IsGo);
    private const string IsJump = nameof(IsJump);

    [SerializeField] private float _speedOfMovement;
    [SerializeField] private float _jumpingForce;
    [SerializeField] private float _lengthRay;

    [SerializeField] private CoinSpowner _spowner;
    [SerializeField] private Transform _playerSpawnPoint;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private bool _isButtonPressed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        PressButtonJump();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _spowner.ReturnCoin(coin);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Trap _))
        {
            transform.position = _playerSpawnPoint.position;
        }
    }

    public void Kill()
    {
        transform.position = _playerSpawnPoint.position;
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxisRaw(Horizontal);

        transform.position += transform.right * moveHorizontal * _speedOfMovement * Time.deltaTime;

        StartWalkingAnimation(moveHorizontal);
    }

    private void PressButtonJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isButtonPressed = true;
        }
    }

    private void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _lengthRay);

        if (hit && hit.collider.TryGetComponent(out Ground _) && _isButtonPressed) 
        {
            _rigidbody.AddForce(transform.up * _jumpingForce, ForceMode2D.Impulse);

            _animator.SetBool(IsJump, true);

            _isButtonPressed = false;
        }
        else if(_isButtonPressed == false)
        {
            _animator.SetBool(IsJump, false);
        }
    }

    private void StartWalkingAnimation(float directionMove)
    {
        if (directionMove != 0)
        {
            if (directionMove > 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (directionMove < 0)
            {
                _spriteRenderer.flipX = false;
            }

            _animator.SetBool(IsGo, true);
        }
        else
        {
            _animator.SetBool(IsGo, false);
        }
    }
}
