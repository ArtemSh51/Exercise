using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rotator _rotator;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private Vision _vision;
    [SerializeField] private Patroler _patroler;

    private void Update()
    {
        float direction = _patroler.GetPatrolDirection(_vision.GetTargetPosition(), _vision.IsPlayerVisible());

        _rotator.TurnByY(direction);

        _mover.Move(direction);
    }
}