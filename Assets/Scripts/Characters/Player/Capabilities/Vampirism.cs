using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    private const int AmountOfLifeTaken = 1;

    [SerializeField] private Health _carrierOfAbility;
    [SerializeField] private float _radius;
    [SerializeField] private int _countOfColliders;
    [SerializeField] private int _abilityReloadTime;
    [SerializeField] private int _abilityShutdownTime;

    private Collider2D[] _colliders;

    private Coroutine _healthTheft;
    private Coroutine _reload;

    public float Radius => _radius;

    public event Action<float, int> DisabledAbilityReloadTime;
    public event Action<float, int> EnabledAbilityReloadTime;

    private void Awake()
    {
        _colliders = new Collider2D[_countOfColliders];
    }

    public void TakeAwayHealth()
    {
        if (TryGetEnemy(out Health enemy))
        {
            if (_healthTheft == null)
            {
                _healthTheft = StartCoroutine(TakeHealth(enemy));
            }
        }
    }

    private bool TryGetEnemy(out Health receivedEnemy)
    {
        int countColliders = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _colliders);

        float minDistance = float.MaxValue;

        receivedEnemy = null;

        List<Enemy> enemies = new List<Enemy>();

        for (int i = 0; i < countColliders; i++)
        {
            if (_colliders[i].TryGetComponent(out Enemy enemy))
            {
                enemies.Add(enemy);
            }
        }

        foreach (Enemy enemy in enemies)
        {
            if ((enemy.transform.position - transform.position).magnitude < minDistance)
            {
                minDistance = (enemy.transform.position - transform.position).magnitude;

                if (enemy.TryGetComponent(out Health health))
                {
                    receivedEnemy = health;
                }
            }
        }

        if (receivedEnemy != null)
        {
            return true;
        }

        return false;
    }

    private void TakeHealthFromTarget(IDamageable target)
    {
        _carrierOfAbility.Treat(AmountOfLifeTaken);

        target.TakeDamage(AmountOfLifeTaken);
    }

    private IEnumerator TakeHealth(Health enemy)
    {
        float time = 0;

        while (time < _abilityShutdownTime)
        {
            if (_carrierOfAbility.Value < _carrierOfAbility.MaxValue && enemy.Value > 0)
            {
                TakeHealthFromTarget(enemy);
            }

            time += Time.deltaTime;

            DisabledAbilityReloadTime?.Invoke(time, _abilityShutdownTime);

            yield return null;
        }

        if (_healthTheft != null)
        {
            StopCoroutine(_healthTheft);

            _healthTheft = null;
        }

        if (_reload == null)
        {
            _reload = StartCoroutine(RebootAbility());
        }
    }

    private IEnumerator RebootAbility()
    {
        float time = 0;

        while (time < _abilityReloadTime)
        {
            time += Time.deltaTime;

            EnabledAbilityReloadTime?.Invoke(time, _abilityReloadTime);

            yield return null;
        }

        if (_reload != null)
        {
            StopCoroutine(_reload);

            _reload = null;
        }
    }
}
