using System;

public class ModelCharacter : IDisposable
{
    private Health _health;

    public ModelCharacter(Health health)
    {
        _health = health;

        _health.HealthChanged += NotifyHealthChanged;
    }

    public event Action<int, int> HealthChanged;

    public void Dispose()
    {
        _health.HealthChanged -= NotifyHealthChanged;
    }

    private void NotifyHealthChanged(int maxHealth, int currentHealth)
    {
        HealthChanged?.Invoke(maxHealth, currentHealth);
    }
}
