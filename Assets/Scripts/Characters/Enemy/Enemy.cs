using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rotator _rotator;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Vision _vision;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Chaser _chaser;
    [SerializeField] private EnemyAttacker _attacker;

    private Coroutine _visionCoroutine;
    private Coroutine _attackCoroutine;

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

        direction = _patroller.GetPatrolDirection();

        if (_vision.IsPlayerVisible())
        {
            if (_visionCoroutine == null)
            {
                _visionCoroutine = StartCoroutine(_chaser.ChaseTarget(_vision.GetTargetPosition()));
            }

            if (_attackCoroutine == null)
            {
                _attackCoroutine = StartCoroutine(_attacker.Attacking());
            }
        }

        _rotator.TurnByY(direction);

        _mover.Move(direction);
    }

    private void FinishCoroutineWork()
    {
        if (_visionCoroutine != null)
        {
            StopCoroutine(_visionCoroutine);

            _visionCoroutine = null;
        }

        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);

            _attackCoroutine = null;
        }
    }
}