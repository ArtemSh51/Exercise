using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Viewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _healthFingerSlider;

    [SerializeField] private Button _healingButton;
    [SerializeField] private int _treatmentUnits;

    [SerializeField] private Button _takeDamageButton;
    [SerializeField] private int _damageReceivedUnits;

    [SerializeField] private float _smoothnessHealthFingerSlider;

    private float _currentHealthFingerSlider;
    private float _targetHealthFingerSlider;

    public event Action<int> HealingButtonPressed;
    public event Action<int> TakeDamageButtonPressed;

    private void OnEnable()
    {
        _healingButton.onClick.AddListener(NotifyHealingButtonPressed);
        _takeDamageButton.onClick.AddListener(NotifyTakeDamageButtonPressed);
    }

    private void OnDisable()
    {
        _healingButton.onClick.RemoveListener(NotifyHealingButtonPressed);
        _takeDamageButton.onClick.RemoveListener(NotifyTakeDamageButtonPressed);
    }

    public void UpdateHealth(int maxHealth, int currentHealth)
    {
        _healthText.text = $"Текущее здоровье: {currentHealth} / {maxHealth}";

        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = currentHealth;

        _healthFingerSlider.maxValue = maxHealth;

        if (currentHealth == maxHealth)
        {
            _currentHealthFingerSlider = maxHealth;
            _targetHealthFingerSlider = maxHealth;
        }

        _targetHealthFingerSlider = currentHealth;
    }

    private void Update()
    {
        _currentHealthFingerSlider = Mathf.MoveTowards(_currentHealthFingerSlider, _targetHealthFingerSlider, _smoothnessHealthFingerSlider);

        _healthFingerSlider.value = _currentHealthFingerSlider;
    }

    private void NotifyHealingButtonPressed()
    {
        HealingButtonPressed?.Invoke(_treatmentUnits);
    }

    private void NotifyTakeDamageButtonPressed()
    {
        TakeDamageButtonPressed?.Invoke(_damageReceivedUnits);
    }
}
