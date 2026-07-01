using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime;
    [SerializeField] private float _touchDistance;

    private Transform _target;

    public event Action<Enemy> LifetimePassed;

    private void OnEnable()
    {
        StartCoroutine(SpecifyLifetime());
    }

    private void Update()
    {
        SetRotation();
        Move();
        CatchTarget();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void SetRotation()
    {
        Vector3 targetPosition = _target.position;

        targetPosition.y = 0;

        transform.right = targetPosition;
    }

    private IEnumerator SpecifyLifetime()
    {
        yield return new WaitForSeconds(_lifetime);

        LifetimePassed?.Invoke(this);
    }

    private void Move()
    {
        Vector3 target = new Vector3(_target.position.x, transform.position.y, _target.position.z);

        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void CatchTarget()
    {
        if ((_target.position - transform.position).sqrMagnitude <= _touchDistance * _touchDistance)
        {
            LifetimePassed?.Invoke(this);
        }
    }
}
