using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _rayLength;

    private float _patrolDirection = 1;

    public float GetPatrolDirection()
    {
        if (IsStandingOnEdge())
        {
            _patrolDirection *= -1;
        }

        return _patrolDirection;
    }

    public void SetDirection(float direction)
    {
        _patrolDirection = direction;
    }

    private bool IsStandingOnEdge()
    {
        return !Physics2D.Raycast(transform.position, -transform.up, _rayLength);
    }
}