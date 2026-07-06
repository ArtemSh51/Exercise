using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _lenghtRay;

    private RaycastHit2D hit;

    private void Update()
    {
        hit = Physics2D.Raycast(transform.position, -transform.right, _lenghtRay);
    }

    public void DealDamage()
    {
        if (hit && hit.collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
    }
}
