using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.CoroutineWorking += UpdateText;
    }

    private void OnDisable()
    {
        _counter.CoroutineWorking -= UpdateText;
    }

    private void UpdateText()
    {
        _text.text = _counter.Number.ToString();

        Debug.Log(_counter.Number);
    }
}
