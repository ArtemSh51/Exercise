using System;

public class Model : IDisposable
{
    private Vampirism _vampirism;

    public Model(Vampirism vampirism)
    {
        _vampirism = vampirism;

        _vampirism.EnabledAbilityReloadTime += NotifyEnabledAbilityReloadTime;

        _vampirism.DisabledAbilityReloadTime += NotifyDisabledAbilityReloadTime;
    }

    public event Action<float, int> EnabledAbilityReloadTime;
    public event Action<float, int> DisabledAbilityReloadTime;

    public void SearchForTarget()
    {
        _vampirism.TakeAwayHealth();
    }

    public void Dispose()
    {
        _vampirism.EnabledAbilityReloadTime -= NotifyEnabledAbilityReloadTime;

        _vampirism.DisabledAbilityReloadTime -= NotifyDisabledAbilityReloadTime;
    }

    private void NotifyEnabledAbilityReloadTime(float currentTime, int abilityReloadTime)
    {
        EnabledAbilityReloadTime?.Invoke(currentTime, abilityReloadTime);
    }

    private void NotifyDisabledAbilityReloadTime(float currentTime, int abilityReloadTime)
    {
        DisabledAbilityReloadTime?.Invoke(currentTime, abilityReloadTime);
    }
}
