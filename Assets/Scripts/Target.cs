using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private List<Transform> _dots;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToPoint;

    private Vector3 _currentPoint;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _currentPoint.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, _currentPoint, _speed * Time.deltaTime);

        if ((_currentPoint - transform.position).sqrMagnitude <= _distanceToPoint * _distanceToPoint)
        {
            _currentPoint = _dots[Random.Range(0, _dots.Count)].position;
        }
    }
}
