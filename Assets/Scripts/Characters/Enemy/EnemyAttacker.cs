using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _lenghtRay;
    [SerializeField] private float _deltaTime;

    private bool _canAttack = true;

    public IEnumerator Attacking()
    {
        WaitForSeconds wait = new WaitForSeconds(_deltaTime);

        while (_canAttack)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _lenghtRay);

            if (hit && hit.collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
            }

            yield return wait;
        }
    }
}