using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private AnimationController _animator;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAttacker _playerAttacker;

    private void OnEnable()
    {
        _inputReader.ButtonJumpPressed += _mover.Jump;

        _inputReader.ButtonAttackPressed += _playerAttacker.DealDamage;
    }

    private void OnDisable()
    {
        _inputReader.ButtonJumpPressed -= _mover.Jump;

        _inputReader.ButtonAttackPressed -= _playerAttacker.DealDamage;
    }

    private void Update()
    {
        float moveHorizontal = _inputReader.GetHorizontalMovementValue();

        KeyCode keyCodeAttack = _inputReader.GetKeyAttack();

        _mover.Move(moveHorizontal);

        _rotator.TurnByY(moveHorizontal);

        _inputReader.ProcessJumpInput(_groundChecker.IsGrounded);
        _inputReader.ProcessAttackInput();

        _animator.StartWalkingAnimation(moveHorizontal);
        _animator.StartJumpingAnimation(_groundChecker.IsGrounded);
        _animator.StartAttackingAnimation(keyCodeAttack);
    }
}