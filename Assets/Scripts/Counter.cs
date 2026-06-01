using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private float _delayTime;

    public event Action<int> NumberIncreasing;

    public int Number { get; private set; }

    private void OnEnable()
    {
        _reader.ButtonPressed += TurnOnCoroutine;
    }

    private void OnDisable()
    {
        _reader.ButtonPressed -= TurnOnCoroutine;
    }

    private void TurnOnCoroutine()
    {
        StartCoroutine(IncreaseNumber());
    }

    private IEnumerator IncreaseNumber()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayTime);

        while (_reader.IsCounterWorking)
        {
            Number++;

            NumberIncreasing?.Invoke(Number);

            yield return wait;
        }
    }
}
