using UnityEngine;

public class ViewerCharacter : MonoBehaviour, IViewCharacter
{
    [SerializeField] private HealthFingerSlider _healthFingerSlider;

    public void UpdateHealth(int maxHealth, int currentHealth)
    {
        _healthFingerSlider.UpdateHealth(maxHealth, currentHealth);
    }
}
