using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    [SerializeField] private int _healthGainFromTreatment;

    public void HealCharacter(Transform character)
    {
        if (character.TryGetComponent(out IRecoverable recoverable))
        {
            recoverable.Treat(_healthGainFromTreatment);

            Destroy(gameObject);
        }
    }
}
