using UnityEngine;

public class CubeClickHander : MonoBehaviour
{
    [SerializeField] private CubeMaker _maker;
    [SerializeField] private CubesExploder _exploder;
    [SerializeField] private CubeInputDetector _inputDetector;

    private void OnEnable()
    {
        _inputDetector.ButtonPressed += HandleCubeClick;
    }

    private void OnDisable()
    {
        _inputDetector.ButtonPressed -= HandleCubeClick;
    }

    private void HandleCubeClick(Cube cube)
    {
        if (Random.value <= cube.ChanceOfDivision)
        {
            _exploder.ExplosionOfCreatedCubes(_maker.CreateNewCubes(cube), cube);
        }
        else
        {
            _exploder.ExplosionOfPressedCube(cube);
        }

        _maker.RemoveCube(cube);
    }
}
