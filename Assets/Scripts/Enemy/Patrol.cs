using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rayLength;

    private float _direction = 1;

    public void Move()
    {
        if (IsStandingOnEdgeOfPlatform())
        {
            _direction *= -1;
        }

        transform.position += transform.right * _direction * _speed * Time.fixedDeltaTime;
    }

    private bool IsStandingOnEdgeOfPlatform()
    {
        return Physics2D.Raycast(transform.position, -transform.up, _rayLength) ? false : true;
    }
}
