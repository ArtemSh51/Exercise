using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime;

    public event Action<Enemy> LifetimePassed;

    private void OnEnable()
    {
        StartCoroutine(SpecifyLifetime());
    }

    private void Update()
    {
        Move();
    }

    public IEnumerator SpecifyLifetime()
    {
        yield return new WaitForSeconds(_lifetime);

        LifetimePassed?.Invoke(this);
    }

    private void Move()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }
}
