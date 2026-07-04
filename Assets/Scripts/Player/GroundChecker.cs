using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Trap _))
        {
            transform.position = _playerSpawnPoint.position;
        }
    }
}
