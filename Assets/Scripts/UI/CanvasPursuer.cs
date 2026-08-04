using UnityEngine;

public class CanvasPursuer : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        float y = _target.position.y + _target.localScale.y / 2 + 1;
        transform.position = new Vector3(_target.position.x, y, _target.position.z);
    }
}
