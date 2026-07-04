using UnityEngine;

[RequireComponent(typeof(Mover), typeof(AnimationController), typeof(ItemPicker))]
public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private AnimationController _animator;
    [SerializeField] private ItemPicker _itemPicker;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _animator = GetComponent<AnimationController>();
        _itemPicker = GetComponent<ItemPicker>();
    }

    private void Update()
    {
        _mover.Move();
        _mover.PressButtonJump();

        _animator.StartWalkingAnimation(_mover.PressMotionButton());
        _animator.StartJumpingAnimation(_mover.GetRay(), _mover.IsGrounded);
    }

    private void FixedUpdate()
    {
        _mover.Jump();
    }
}
