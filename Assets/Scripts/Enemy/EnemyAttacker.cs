using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _lenghtRay;
    [SerializeField] private float _deltaTime;

    private void Start()
    {
        StartCoroutine(DealingDamage());
    }

    private IEnumerator DealingDamage()
    {
        WaitForSeconds wait = new WaitForSeconds(_deltaTime);

        RaycastHit2D hit;

        while (true)
        {
            hit = Physics2D.Raycast(transform.position, transform.right, _lenghtRay);

            if (hit && hit.collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
            }

            yield return wait;
        }
    }
}
