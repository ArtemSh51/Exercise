using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private HealthHandler _healthHandler;
    [SerializeField] private GroundChecker _groundChecker;

    private void OnEnable()
    {
        _healthHandler.PlayerKilled += ReturnToRespawnPoint;

        _groundChecker.PlayerTouchedTrap += ReturnToRespawnPoint;
    }

    private void OnDisable()
    {
        _healthHandler.PlayerKilled -= ReturnToRespawnPoint;

        _groundChecker.PlayerTouchedTrap -= ReturnToRespawnPoint;
    }

    private void ReturnToRespawnPoint(Transform player)
    {
        player.position = transform.position;

        _healthHandler.Restore();
    }
}
