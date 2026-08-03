using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSlider : MonoBehaviour
{
    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    public void UpdateHealth(int maxHealth, int currentHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = currentHealth;
    }
}
