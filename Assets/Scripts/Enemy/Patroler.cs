using System.Collections;
using UnityEngine;

public class Patroler : MonoBehaviour
{
    [SerializeField] private float _rayLength;
    [SerializeField] private float _timeOfPursuit;

    private float _patrolDirection = 1;

    private Coroutine _coroutine;

    public float GetPatrolDirection(Transform target, bool isPlayerVisible)
    {
        if (IsStandingOnEdgeOfPlatform())
        {
            _patrolDirection *= -1;

            if (_coroutine != null)
            {
                _coroutine = null;
            }
        }
        else if (isPlayerVisible && _coroutine == null)
        {
            _coroutine = StartCoroutine(ChaseTarget(target));
        }

        return _patrolDirection;
    }

    private bool IsStandingOnEdgeOfPlatform()
    {
        return Physics2D.Raycast(transform.position, -transform.up, _rayLength) ? false : true;
    }

    private IEnumerator ChaseTarget(Transform target)
    {
        float currentTime = 0;

        while (currentTime <= _timeOfPursuit)
        {
            float difference = Mathf.Sign(target.position.x - transform.position.x);

            _patrolDirection = difference;

            currentTime += Time.deltaTime;

            yield return null;
        }
    }
}
