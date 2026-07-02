using System.Collections.Generic;
using UnityEngine;

class RouteCustomizer : MonoBehaviour
{
    [SerializeField] private List<Transform> _routePoints;
    [SerializeField] private Traveler _traveler;

    private int _currentPointIndex = 0;

    private void OnEnable()
    {
        _traveler.PointOccupied += PassCoordinatesOfNewPoint;
    }

    private void OnDisable()
    {
        _traveler.PointOccupied -= PassCoordinatesOfNewPoint;
    }

    private void PassCoordinatesOfNewPoint()
    {
        _traveler.SetCurrentPoint(GetNewRoutePoint());
    }

    private Vector3 GetNewRoutePoint()
    {
        _currentPointIndex++;

        if (_currentPointIndex == _routePoints.Count)
        {
            _currentPointIndex = 0;
        }

        Vector3 newPoint = _routePoints[_currentPointIndex].position;

        return newPoint;
    }
}