using UnityEngine;

[RequireComponent(typeof(Mover), typeof(AnimationController), typeof(ItemPicker))]
[RequireComponent(typeof(Rotator), typeof(Inputer), typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private AnimationController _animator;
    [SerializeField] private ItemPicker _itemPicker;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Inputer _inputer;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _animator = GetComponent<AnimationController>();
        _itemPicker = GetComponent<ItemPicker>();
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        float moveHorizontal = _inputer.GetHorizontalMovementValue();

        _mover.Move(moveHorizontal);

        _inputer.PressButtonJump();

        _rotator.TurnByY(moveHorizontal);

        _animator.StartWalkingAnimation(moveHorizontal);
        _animator.StartJumpingAnimation(_mover.IsGrounded);
    }
}
