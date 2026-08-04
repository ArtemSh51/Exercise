using UnityEngine;

public class Presenter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Viewer _viewer;

    private IView _view;

    private void Awake()
    {
        _view = _viewer;
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealth;
    }

    private void UpdateHealth(int maxHealth, int currentHealth)
    {
        _view.UpdateHealth(maxHealth, currentHealth);
    }
}
