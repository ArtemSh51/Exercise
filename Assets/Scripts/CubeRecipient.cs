using System;
using UnityEngine;

public class CubeRecipient : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public event Action<RaycastHit> ButtonPressed;

    private Ray _ray;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(_ray, out hit) && hit.transform.TryGetComponent(out Cube cube))
            {
                ButtonPressed?.Invoke(hit);
            }
        }
    }
}
