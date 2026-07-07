using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rotator _rotator;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Vision _vision;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Chaser _chaser;
    [SerializeField] private EnemyAttacker _attacker;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _chaser.DirectionUpdated += _patroller.SetDirection;

        _chaser.PursuitStopped += FinishCoroutineWork;
    }

    private void OnDisable()
    {
        _chaser.DirectionUpdated -= _patroller.SetDirection;

        _chaser.PursuitStopped -= FinishCoroutineWork;
    }

    private void Update()
    {
        float direction = 1;

        if (_vision.IsPlayerVisible())
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(_chaser.ChaseTarget(_vision.GetTargetPosition()));
            }

            if (_attacker.CanAttack())
            {
                _attacker.Attack();
            }
        }
        else
        {
            direction = _patroller.GetPatrolDirection();
        }

        _rotator.TurnByY(direction);

        _mover.Move(direction);
    }

    private void FinishCoroutineWork()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }
    }
}