using System;

interface IView
{
    event Action PressedButton;

    void NotifyButtonPressed();

    void ChangedValue(float value);

    void SetEnableButton(bool isEnable);
}
