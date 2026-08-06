using System;
using UnityEngine;

public class Viewer : MonoBehaviour, IView
{
    [SerializeField] private ButtonController _buttonCotroller;
    [SerializeField] private SliderController _sliderController;

    public event Action PressedButton;

    private void OnEnable()
    {
        _buttonCotroller.PressedButton += NotifyButtonPressed;
    }

    private void OnDisable()
    {
        _buttonCotroller.PressedButton -= NotifyButtonPressed;
    }

    public void NotifyButtonPressed()
    {
        PressedButton?.Invoke();
    }

    public void ChangedValue(float value)
    {
        _sliderController.SetValue(value);
    }

    public void SetEnableButton(bool isEnable)
    {
        _buttonCotroller.SetEnabledButton(isEnable);
    }
}
