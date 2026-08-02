using UnityEngine;

public class Presenter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Viewer _viewer;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealth;
        _viewer.HealingButtonPressed += Treat;
        _viewer.TakeDamageButtonPressed += TakeDamage;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealth;
        _viewer.HealingButtonPressed -= Treat;
        _viewer.TakeDamageButtonPressed -= TakeDamage;
    }

    private void Treat(int treatmentUnits)
    {
        _health.Treat(treatmentUnits);
    }

    private void TakeDamage(int damageReceivedUnits)
    {
        _health.TakeDamage(damageReceivedUnits);
    }

    private void UpdateHealth(int maxHealth, int currentHealth)
    {
        _viewer.UpdateHealth(maxHealth, currentHealth);
    }
}
