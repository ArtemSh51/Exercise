using System;
using System.Collections;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private float _timeOfPursuit;

    public event Action<float> DirectionUpdated;

    public event Action PursuitStopped;

    public IEnumerator ChaseTarget(Transform target)
    {
        float timer = 0;

        while (timer < _timeOfPursuit)
        {
            float direction = Mathf.Sign(target.position.x - transform.position.x);

            DirectionUpdated?.Invoke(direction);

            timer += Time.deltaTime;

            yield return null;
        }

        PursuitStopped?.Invoke();
    }
}