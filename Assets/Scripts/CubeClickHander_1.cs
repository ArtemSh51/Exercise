using UnityEngine;

public class CubeClickHander : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeMaker _maker;
    [SerializeField] private CubesExploder _exploder;

    private Ray _ray;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(_ray, out hit) && hit.transform.TryGetComponent(out Cube cube))
            {
                HandleCubeClick(cube);
            }
        }
    }

    private void HandleCubeClick(Cube cube)
    {
        if (Random.value <= cube.ChanceOfDivision)
        {
            _exploder.BlowUp(_maker.CreateNewCubes(cube), cube);
        }

        _maker.RemoveCube(cube);
    }
}
