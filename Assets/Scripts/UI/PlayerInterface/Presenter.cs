using System;

public class Presenter : IDisposable
{
    private Model _model;
    private IView _viewer;

    public Presenter(Model model, Viewer viewer)
    {
        _model = model;
        _viewer = viewer;

        _viewer.PressedButton += TakeHealthFromTarget;

        _model.EnabledAbilityReloadTime += ReloadAbility;

        _model.DisabledAbilityReloadTime += DisablingAbility;
    }

    private void TakeHealthFromTarget()
    {
        _model.SearchForTarget();
    }

    public void Dispose()
    {
        _viewer.PressedButton -= TakeHealthFromTarget;

        _model.EnabledAbilityReloadTime -= ReloadAbility;

        _model.DisabledAbilityReloadTime -= DisablingAbility;
    }

    private void DisablingAbility(float currentTime, int abilityShutdownTime)
    {
        _viewer.SetEnableButton(false);

        _viewer.ChangedValue(currentTime / abilityShutdownTime);
    }

    private void ReloadAbility(float currentTime, int abilityReloadTime)
    {
        bool _canEnableButton = currentTime >= abilityReloadTime;

        _viewer.SetEnableButton(_canEnableButton);

        _viewer.ChangedValue((abilityReloadTime - currentTime) / abilityReloadTime);
    }
}
