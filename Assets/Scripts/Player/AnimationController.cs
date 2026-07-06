using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private static readonly int IsGo = Animator.StringToHash(nameof(IsGo));
    private static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    private static readonly int CanJump = Animator.StringToHash(nameof(CanJump));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartWalkingAnimation(float directionMove)
    {
        if (directionMove != 0)
        {
            _animator.SetBool(IsGo, true);

            _animator.SetBool(IsAttack, false);
        }
        else
        {
            _animator.SetBool(IsGo, false);
        }
    }

    public void StartJumpingAnimation(bool isGrounded)
    {
        bool canJump = isGrounded == false;

        _animator.SetBool(CanJump, canJump);

        _animator.SetBool(IsAttack, false);
    }

    public void StartAttackingAnimation(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            _animator.SetBool(IsAttack, true);
        }
    }
}
