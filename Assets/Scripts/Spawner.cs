using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Transform> _tragets;
    [SerializeField] private Transform _area;

    [SerializeField] private int _defaultCountOfEnemies;
    [SerializeField] private int _poolSize;

    [SerializeField] private float _deltaTime;

    private ObjectPool<Enemy> _enemies;

    private void Awake()
    {
        _enemies = new ObjectPool<Enemy>
        (
            createFunc: () => Instantiate(_enemyPrefab),

            actionOnGet: (enemy) => CustomizeEnemyTakenFromPool(enemy),

            actionOnRelease: (enemy) => CustomizeEnemyReturnedToPool(enemy),

            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),

            collectionCheck: true,

            defaultCapacity: _defaultCountOfEnemies,

            maxSize: _poolSize
        );
    }

    private void Start()
    {
        StartCoroutine(TakeEnemy());
    }

    private IEnumerator TakeEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_deltaTime);

        while (true)
        {
            _enemies.Get();

            yield return wait;
        }
    }

    private void CustomizeEnemyTakenFromPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);

        enemy.LifetimePassed += ReturnEnemy;

        SetPosition(enemy);

        enemy.SetTarget(_tragets[Random.Range(0, _tragets.Count)].transform);
    }

    private void CustomizeEnemyReturnedToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);

        enemy.LifetimePassed -= ReturnEnemy;

        enemy.transform.position = Vector3.zero;

        enemy.transform.rotation = Quaternion.identity;
    }

    private void SetPosition(Enemy enemy)
    {
        float yValue = _area.position.y + GetHalfObjectHeight(_area) + GetHalfObjectHeight(enemy.transform);

        enemy.transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
    }

    private float GetHalfObjectHeight(Transform gameObject)
    {
        const int DivisorOfHeightOfObject = 2;

        return gameObject.localScale.y / DivisorOfHeightOfObject;
    }

    private void ReturnEnemy(Enemy enemy)
    {
        _enemies.Release(enemy);
    }
}
