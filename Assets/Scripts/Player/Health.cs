using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, IRecoverable
{
    [SerializeField, Range(1, 5000)] private float _value;

    private float _maxValue;

    public float Value => _value;

    public event Action<Transform> Died;

    private void Start()
    {
        _maxValue = _value;
    }

    public void TakeDamage(float amount)
    {
        _value -= amount;

        if (_value <= 0)
        {
            Kill();
        }
    }

    public void Restore()
    {
        _value = _maxValue;
    }

    public void Treat(int healthGainFromTreatment)
    {
        if (_value + healthGainFromTreatment <= _maxValue)
        {
            _value += healthGainFromTreatment;
        }
        else
        {
            _value = _maxValue;
        }
    }

    private void Kill()
    {
        Died?.Invoke(transform);
    }
}
