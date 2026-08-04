using UnityEngine;

public class Viewer : MonoBehaviour, IView
{
    [SerializeField] private HealthFingerSlider _healthFingerSlider;

    public void UpdateHealth(int maxHealth, int currentHealth)
    {
        _healthFingerSlider.UpdateHealth(maxHealth, currentHealth);
    }
}
