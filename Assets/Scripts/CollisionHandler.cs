using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action AreaCrossed;
    public event Action AreaAbandoned;

    private void OnTriggerEnter(Collider other)
    {
        AreaCrossed?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        AreaAbandoned?.Invoke();
    }
}
