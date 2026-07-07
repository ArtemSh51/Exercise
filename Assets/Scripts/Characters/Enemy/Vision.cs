using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private float _lenghtRay;

    private RaycastHit2D _hit;

    public RaycastHit2D Hit => _hit;

    private void Update()
    {
        _hit = Physics2D.Raycast(transform.position, transform.right, _lenghtRay);
    }

    public Transform GetTargetPosition()
    {
        if (_hit && _hit.collider.TryGetComponent(out Player player))
        {
            return player.transform;
        }

        return null;
    }

    public bool IsPlayerVisible()
    {
        return _hit && _hit.collider.TryGetComponent(out Player _);
    }
}
