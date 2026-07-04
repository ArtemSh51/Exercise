using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;

    public void Kill()
    {
        transform.position = _playerSpawnPoint.position;
    }
}
