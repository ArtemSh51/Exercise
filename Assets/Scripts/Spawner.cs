using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _defaultCountOfEnemies;
    [SerializeField] private int _poolSize;

    [SerializeField, Delayed] private int _minRotationValueInDegrees = 0;
    [SerializeField, Delayed] private int _maxRotationValueInDegrees = 360;

    [SerializeField] private float _deltaTime;

    [SerializeField] private List<Transform> _spawnPoints;

    private ObjectPool<Enemy> _enemies;

    private void OnValidate()
    {
        if (_minRotationValueInDegrees >= _maxRotationValueInDegrees)
        {
            _maxRotationValueInDegrees = _minRotationValueInDegrees + 1;
        }
    }

    private void Awake()
    {
        _enemies = new ObjectPool<Enemy>
        (
            createFunc: () => Instantiate(_enemyPrefab),

            actionOnGet: (enemy) => CustomizeEnemyTakenFromPpool(enemy),

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

    private void CustomizeEnemyTakenFromPpool(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);

        enemy.LifetimePassed += ReturnEnemy;

        SetPosition(enemy);

        SetRotation(enemy);
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
        const int DivisorOfHeighOfEnemy = 2;

        Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

        float yValue = transform.position.y + enemy.transform.localScale.y / DivisorOfHeighOfEnemy;

        enemy.transform.position = new Vector3(randomSpawnPoint.position.x, yValue, randomSpawnPoint.position.z);
    }

    private void SetRotation(Enemy enemy)
    {
        float randomRotationValueInDegrees = Random.Range(_minRotationValueInDegrees, _maxRotationValueInDegrees);

        enemy.transform.rotation = Quaternion.Euler(0, randomRotationValueInDegrees, 0);
    }

    private void ReturnEnemy(Enemy enemy)
    {
        _enemies.Release(enemy);
    }
}
