using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetime;

    private Coroutine _coroutine;
    private Rigidbody _rigidbody;

    public event Action<Bullet> LifetimeEnded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(StartLifeTimer());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }
    }

    public void SetFlightForce(Vector3 targetDirection, float force)
    {
        _rigidbody.transform.up = targetDirection;

        _rigidbody.velocity = targetDirection * force;
    }

    private IEnumerator StartLifeTimer()
    {
        yield return new WaitForSeconds(_lifetime);

        LifetimeEnded?.Invoke(this);
    }
}
