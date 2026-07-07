using System;
using UnityEngine;

public class TrapChecker : MonoBehaviour
{
    public event Action<Transform> PlayerTouchedTrap;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Trap _))
        {
            PlayerTouchedTrap?.Invoke(transform);
        }
    }
}
