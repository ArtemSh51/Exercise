using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private static readonly int IsGo = Animator.StringToHash(nameof(IsGo));
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
        }
        else
        {
            _animator.SetBool(IsGo, false);
        }
    }

    public void StartJumpingAnimation(RaycastHit2D hit, bool _isGrounded)
    {
        bool canJump = _isGrounded == false;

        _animator.SetBool(CanJump, canJump);
    }
}
