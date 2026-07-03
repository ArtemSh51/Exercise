using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action AreaCrossed;
    public event Action AreaAbandoned;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief _))
        {
            AreaCrossed?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief _))
        {
            AreaAbandoned?.Invoke();
        }
    }
}
