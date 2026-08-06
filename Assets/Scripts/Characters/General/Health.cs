using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, IRecoverable
{
    [SerializeField, Range(1, 5000)] private int _value;

    private int _maxValue;

    public int Value => _value;

    public int MaxValue => _maxValue;

    public event Action<int, int> HealthChanged;

    public event Action<Transform> Died;

    private void Start()
    {
        _maxValue = _value;

        HealthChanged?.Invoke(_maxValue, _value);
    }

    public void TakeDamage(int amount)
    {
        _value = Mathf.Clamp(_value -  amount, 0, _maxValue);

        if (_value <= 0)
        {
            Kill();
        }

        HealthChanged?.Invoke(_maxValue, _value);
    }

    public void Restore()
    {
        _value = _maxValue;

        HealthChanged?.Invoke(_maxValue, _value);
    }

    public void Treat(int healthGainFromTreatment)
    {
        if (healthGainFromTreatment <= 0)
        {
            healthGainFromTreatment = 0;
        }

        _value = Mathf.Clamp(_value + healthGainFromTreatment, 0, _maxValue);

        HealthChanged?.Invoke(_maxValue, _value);
    }

    private void Kill()
    {
        Died?.Invoke(transform);
    }
}
