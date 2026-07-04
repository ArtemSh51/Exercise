using UnityEngine;

public class Attacking : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.Kill();
        }
    }
}
