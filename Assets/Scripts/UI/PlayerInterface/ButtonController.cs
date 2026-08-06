using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    private Button _button;

    public event Action PressedButton;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(NotifyButtonPressed);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(NotifyButtonPressed);
    }

    public void SetEnabledButton(bool isEnable)
    {
        _button.enabled = isEnable;
    }

    private void NotifyButtonPressed()
    {
        PressedButton?.Invoke();
    }
}
