using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private Health _healthHandler;
    [SerializeField] private TrapChecker _groundChecker;
    [SerializeField] private bool _canRespawn;

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
        if (_canRespawn)
        {
            character.position = transform.position;
            _healthHandler.Restore();
        }
        else
        {
            Destroy(character.gameObject);
        }
    }
}
