using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private float _delayTime;

    public event Action<int> NumberIncreasing;

    private bool _isCounterWorking;
    private Coroutine _coroutine;

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
        _isCounterWorking = _isCounterWorking ? false : true;

        if (_isCounterWorking)
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(IncreaseNumber());
            }
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);

                _coroutine = null;
            }
        }
    }

    private IEnumerator IncreaseNumber()
    {
        WaitForSeconds wait = new WaitForSeconds(_delayTime);

        while (_isCounterWorking)
        {
            Number++;

            NumberIncreasing?.Invoke(Number);

            yield return wait;
        }

        _coroutine = null;
    }
}
