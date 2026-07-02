using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

class Gun : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _timeWaitShooting;

    [SerializeField] private Transform _target;
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private int _defaultCountOfBullets;
    [SerializeField] private int _sizePool;

    private ObjectPool<Bullet> _bullets;

    private void Awake()
    {
        _bullets = new ObjectPool<Bullet>
        (
            createFunc: () => Instantiate(_bulletPrefab),
            
            actionOnGet: (bullet) => PrepareBulletBeforeUse(bullet),
            
            actionOnRelease: (bullet) => PrepareBulletBeforeReturning(bullet),

            actionOnDestroy: (bullet) => Destroy(bullet.gameObject),

            collectionCheck: true,

            defaultCapacity: _defaultCountOfBullets,

            maxSize: _sizePool
        );
    }

    private void Start()
    {
        StartCoroutine(CreateBullets());
    }

    private void PrepareBulletBeforeUse(Bullet bullet)
    {
        bullet.LifetimeEnded += ReturnBullet;

        bullet.transform.position = transform.position;

        bullet.gameObject.SetActive(true);
    }

    private void PrepareBulletBeforeReturning(Bullet bullet)
    {
        bullet.LifetimeEnded -= ReturnBullet;

        bullet.transform.position = Vector3.zero;

        bullet.transform.rotation = Quaternion.identity;

        bullet.gameObject.SetActive(false);
    }

    private IEnumerator CreateBullets()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeWaitShooting);

        while (true)
        {
            TakeBullet();

            yield return wait;
        }
    }

    private void TakeBullet()
    {
        Vector3 targetDirection = (_target.position - transform.position).normalized;

        Bullet newBullet = _bullets.Get();

        if (newBullet.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.transform.up = targetDirection;
            rigidbody.velocity = targetDirection * _force;
        }
    }

    private void ReturnBullet(Bullet bullet)
    {
        _bullets.Release(bullet);
    }
}