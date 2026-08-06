using UnityEngine;

public class Respawner : MonoBehaviour
{
    private const bool CanRespawn = true;
    
    [SerializeField] private Health _healthHandler;
    [SerializeField] private TrapChecker _groundChecker;

    private void OnEnable()
    {
        _healthHandler.Died += ReturnToRespawnPoint;

        _groundChecker.PlayerTouchedTrap += ReturnToRespawnPoint;
    }

    private void OnDisable()
    {
        _healthHandler.Died -= ReturnToRespawnPoint;

        _groundChecker.PlayerTouchedTrap -= ReturnToRespawnPoint;
    }

    private void ReturnToRespawnPoint(Transform character)
    {
        if (CanRespawn)
        {
            character.position = transform.position;
            _healthHandler.Restore();
        }
    }
}
