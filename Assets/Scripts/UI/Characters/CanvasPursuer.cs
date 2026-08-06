using UnityEngine;

public class CanvasPursuer : MonoBehaviour
{
    private const int HeightDivider = 2;

    [SerializeField] private Transform _target;
    [SerializeField] private float _heightAboveTarget;

    private void Update()
    {
        float yPosition = _target.position.y + _target.localScale.y / HeightDivider + _heightAboveTarget;
        transform.position = new Vector3(_target.position.x, yPosition, _target.position.z);
    }
}
