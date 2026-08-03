using System;

interface IView
{
    event Action<int> HealingButtonPressed;
    event Action<int> TakeDamageButtonPressed;

    void UpdateHealth(int maxHealth, int currentHealth);
}
