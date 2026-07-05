using System;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamageable
{
    public event Action<Transform> PlayerKilled;

    public void Kill()
    {
        PlayerKilled?.Invoke(transform);
    }
}
