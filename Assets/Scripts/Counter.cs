using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _reader;

    public event Action CoroutineWorking;

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
        while (_reader.IsCounterWorking)
        {
            Number++;

            CoroutineWorking?.Invoke();

            yield return new WaitForSeconds(0.5f);
        }
    }
}
