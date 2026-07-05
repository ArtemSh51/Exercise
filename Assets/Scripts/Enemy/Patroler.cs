using UnityEngine;

public class Patroler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rayLength;

    [SerializeField] private Transform _target;
    [SerializeField] private float _distanceToTarget;

    private float _direction = 1;

    public float Direction => _direction;

    public void Move()
    {
        if (IsStandingOnEdgeOfPlatform())
        {
            _direction *= -1;
        }

        transform.position += Vector3.right * _direction * _speed * Time.fixedDeltaTime;
    }

    public void PursueTarget()
    {
        if (IsDetectedTarget() && IsStandingOnEdgeOfPlatform() == false)
        {
            _direction = Mathf.Sign(_target.position.x - transform.position.x);
        }
    }

    private bool IsStandingOnEdgeOfPlatform()
    {
        return Physics2D.Raycast(transform.position, -transform.up, _rayLength) ? false : true;
    }

    private bool IsDetectedTarget()
    {
        return (_target.position - transform.position).sqrMagnitude <= _distanceToTarget * _distanceToTarget;
    }
}
