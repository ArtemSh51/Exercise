using System;
using UnityEngine;

public class HealthHandler : MonoBehaviour, IDamageable
{
    [SerializeField, Range(1, 5000)] private float _value;

    private float _maxValue;

    public event Action<Transform> PlayerKilled;

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

    public void Kill()
    {
        PlayerKilled?.Invoke(transform);
    }

    public void Restore()
    {
        _value = _maxValue;
    }
}
