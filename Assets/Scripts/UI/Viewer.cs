using System;
using UnityEngine;

public class Viewer : MonoBehaviour, IView
{
    [SerializeField] private HealthText _healthText;
    [SerializeField] private HealthSlider _healthSlider;
    [SerializeField] private HealthFingerSlider _healthFingerSlider;
    [SerializeField] private ButtonController _healingButton;
    [SerializeField] private ButtonController _takeDamageButton;

    public event Action<int> HealingButtonPressed;
    public event Action<int> TakeDamageButtonPressed;

    private void OnEnable()
    {
        _healingButton.ButtonPressed += NotifyHealingButtonPressed;
        _takeDamageButton.ButtonPressed += NotifyTakeDamageButtonPressed;
    }

    private void OnDisable()
    {
        _healingButton.ButtonPressed -= NotifyHealingButtonPressed;
        _takeDamageButton.ButtonPressed -= NotifyTakeDamageButtonPressed;
    }

    public void UpdateHealth(int maxHealth, int currentHealth)
    {
        _healthText.UpdateHealth(maxHealth, currentHealth);
        _healthSlider.UpdateHealth(maxHealth, currentHealth);
        _healthFingerSlider.UpdateHealth(maxHealth, currentHealth);
    }

    private void NotifyHealingButtonPressed(int treatmentUnits)
    {
        HealingButtonPressed?.Invoke(treatmentUnits);
    }

    private void NotifyTakeDamageButtonPressed(int damageReceivedUnits)
    {
        TakeDamageButtonPressed?.Invoke(damageReceivedUnits);
    }
}
