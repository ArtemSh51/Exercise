using System;

public class PresenterCharacter : IDisposable
{
    private ModelCharacter _model;
    private IViewCharacter _view;

    public PresenterCharacter(ModelCharacter model, ViewerCharacter viewer)
    {
        _model = model;
        _view = viewer;

        _model.HealthChanged += UpdateHealth;
    }

    public void Dispose()
    {
        _model.HealthChanged -= UpdateHealth;
    }

    private void UpdateHealth(int maxHealth, int currentHealth)
    {
        _view.UpdateHealth(maxHealth, currentHealth);
    }
}
