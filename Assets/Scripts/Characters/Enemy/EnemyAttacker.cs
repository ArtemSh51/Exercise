using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _lenghtRay;
    [SerializeField] private float _deltaTime;

    private bool _canAttack = false;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _lenghtRay);

        _canAttack = hit && hit.collider.TryGetComponent(out Player _);
    }

    public bool CanAttack()
    {
        return _canAttack;
    }

    public void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _lenghtRay);

        if (hit && hit.collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
    }
}