using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private HealthManager _healthManager;
    [SerializeField] private GroundChecker _groundChecker;

    private void OnEnable()
    {
        _healthManager.PlayerKilled += ReturnToRespawnPoint;

        _groundChecker.PlayerTouchedTrap += ReturnToRespawnPoint;
    }

    private void OnDisable()
    {
        _healthManager.PlayerKilled -= ReturnToRespawnPoint;

        _groundChecker.PlayerTouchedTrap -= ReturnToRespawnPoint;
    }

    private void ReturnToRespawnPoint(Transform player)
    {
        player.position = transform.position;
    }
}
