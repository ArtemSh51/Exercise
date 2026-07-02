using System;
using System.Collections;
using UnityEngine;

class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetime;

    public event Action<Bullet> LifetimeEnded;

    private void OnEnable()
    {
        StartCoroutine(LiveForWhile());
    }

    private IEnumerator LiveForWhile()
    {
        yield return new WaitForSeconds(_lifetime);

        LifetimeEnded?.Invoke(this);
    }
}
