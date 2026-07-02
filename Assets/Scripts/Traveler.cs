using System;
using UnityEngine;

class Traveler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;

    private Vector3 _currentPoint;

    public event Action PointOccupied;

    private void Awake()
    {
        PointOccupied?.Invoke();
    }

    private void Update()
    {
        GoToPoint();
        ProcessArrival();
    }

    public void SetCurrentPoint(Vector3 currentPoint)
    {
        _currentPoint = currentPoint;
    }

    private void GoToPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint, _speed * Time.deltaTime);
    }

    private void SetRotation()
    {
        transform.forward = _currentPoint - transform.position;
    }

    private void ProcessArrival()
    {
        if ((_currentPoint - transform.position).sqrMagnitude <= _distance * _distance)
        {
            PointOccupied?.Invoke();

            SetRotation();
        }
    }
}
