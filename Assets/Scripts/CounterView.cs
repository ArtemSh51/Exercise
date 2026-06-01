using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.NumberIncreasing += UpdateText;
    }

    private void OnDisable()
    {
        _counter.NumberIncreasing -= UpdateText;
    }

    private void UpdateText(int number)
    {
        _text.text = _counter.Number.ToString();

        Debug.Log(_counter.Number);
    }
}
