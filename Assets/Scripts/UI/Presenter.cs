using UnityEngine;

public class Presenter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthText _healthText;
    [SerializeField] private HealthSlider _healthSlider;
    [SerializeField] private HealthFingerSlider _healthFingerSlider;
    [SerializeField] private ButtonController _healingButton;
    [SerializeField] private ButtonController _takeDamageButton;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealth;
        _healingButton.ButtonPressed += Treat;
        _takeDamageButton.ButtonPressed += TakeDamage;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealth;
        _healingButton.ButtonPressed -= Treat;
        _takeDamageButton.ButtonPressed -= TakeDamage;
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
        _healthText.UpdateHealth(maxHealth, currentHealth);
        _healthSlider.UpdateHealth(maxHealth, currentHealth);
        _healthFingerSlider.UpdateHealth(maxHealth, currentHealth);
    }
}
