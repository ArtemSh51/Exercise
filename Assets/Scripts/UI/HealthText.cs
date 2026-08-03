using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthText : MonoBehaviour
{
    private TextMeshProUGUI _healthText;

    private void Awake()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateHealth(int maxHealth, int currentHealth)
    {
        _healthText.text = $"Текущее здоровье: {currentHealth} / {maxHealth}";
    }
}
