using UnityEngine;

public class HealingPotion : MonoBehaviour, IPickableWithPicker
{
    [SerializeField] private int _healthGainFromTreatment;

    public void PickUp(Transform character)
    {
        if (character.TryGetComponent(out IRecoverable recoverable))
        {
            recoverable.Treat(_healthGainFromTreatment);

            Destroy(gameObject);
        }
    }
}
