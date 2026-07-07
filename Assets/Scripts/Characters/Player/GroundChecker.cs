using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _radius = 0.2f;
    [SerializeField] private float _distance = 0.5f;
    [SerializeField] private float _checkInterval = 0.02f;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded { get; private set; }

    private void Start()
    {
        StartCoroutine(MonitorGround());
    }

    private IEnumerator MonitorGround()
    {
        var wait = new WaitForSeconds(_checkInterval);

        while (true)
        {
            yield return wait;

            Vector2 origin = (Vector2)transform.position + Vector2.down * 0.1f;

            RaycastHit2D hit = Physics2D.CircleCast(origin, _radius, Vector2.down, _distance, _groundLayer);

            IsGrounded = hit.collider != null;
        }
    }
}