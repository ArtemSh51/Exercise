using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rayLength;

    private float _direction = 1;

    private void FixedUpdate()
    {
        if (CheckPlatformExit())
        {
            _direction *= -1;
        }

        transform.position += transform.right * _direction * _speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.Kill();
        }
    }

    private bool CheckPlatformExit()
    {
        bool isEdgeOfPlatform;

        if (Physics2D.Raycast(transform.position, -transform.up, _rayLength))
        {
            isEdgeOfPlatform = false;
        }
        else
        {
            isEdgeOfPlatform = true;
        }

        return isEdgeOfPlatform;
    }
}
