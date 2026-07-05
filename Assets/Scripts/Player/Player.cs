using UnityEngine;

[RequireComponent(typeof(Mover), typeof(AnimationController), typeof(ItemPicker))]
[RequireComponent(typeof(Rotator), typeof(Inputer), typeof(HealthManager))]
public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private AnimationController _animator;
    [SerializeField] private ItemPicker _itemPicker;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private Inputer _inputer;
    [SerializeField] private HealthManager _healthManager;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _animator = GetComponent<AnimationController>();
        _itemPicker = GetComponent<ItemPicker>();
        _rotator = GetComponent<Rotator>();
        _healthManager = GetComponent<HealthManager>();
    }

    private void Update()
    {
        _mover.Move();

        _inputer.PressButtonJump();

        _rotator.TurnByY(_mover.PressMotionButton());

        _animator.StartWalkingAnimation(_mover.PressMotionButton());
        _animator.StartJumpingAnimation(_mover.IsGrounded);
    }
}
