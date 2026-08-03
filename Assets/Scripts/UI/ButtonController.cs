using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    [SerializeField] private int _value;

    private Button _button;

    public event Action<int> ButtonPressed;

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

    private void NotifyButtonPressed()
    {
        ButtonPressed?.Invoke(_value);
    }
}
