using System;
using UnityEngine;

public class CubeMaker : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private CubeRecipient _recipient;

    [SerializeField, Min(0)] private int _minCountOfCubes;
    [SerializeField, Min(0)] private int _maxCountOfCubes;

    public event Action<Cube> CubesCreated;

    private void OnEnable()
    {
        _recipient.ButtonPressed += CreateNewCubes;
    }

    private void OnDisable()
    {
        _recipient.ButtonPressed -= CreateNewCubes;
    }

    private void OnValidate()
    {
        if (_minCountOfCubes >= _maxCountOfCubes)
        {
            _maxCountOfCubes = _minCountOfCubes + 1;
        }
    }

    public void CreateNewCubes(Cube cube)
    {
        if (UnityEngine.Random.value <= cube.ChanceOfDivision)
        {
            float currentChanceOfDivision = cube.ChanceOfDivision;
            float reductionFactor = 2;
            float divider = 2;

            float numberOfCubes = UnityEngine.Random.Range(_minCountOfCubes, _maxCountOfCubes);

            for (int i = 0; i < numberOfCubes; i++)
            {
                Cube newCube = Instantiate(_cube, GetPositionOfCube(cube), Quaternion.identity);

                newCube.transform.localScale = new Vector3(cube.transform.localScale.x / divider,
                                                 cube.transform.localScale.y / divider,
                                                 cube.transform.localScale.z / divider);

                newCube.SetRandomColor();

                newCube.SetChanceOfDivision(currentChanceOfDivision, reductionFactor);
            }

            CubesCreated?.Invoke(cube);
        }

        RemoveCube(cube);
    }

    private Vector3 GetPositionOfCube(Cube cube)
    {
        float negativeAxis = -1;
        float positiveAxis = 1;

        float randomIncreaseToPosition = UnityEngine.Random.Range(negativeAxis, positiveAxis);

        return cube.transform.position + randomIncreaseToPosition * (cube.transform.right + cube.transform.forward).normalized;
    }

    public void RemoveCube(Cube cube)
    {
        Destroy(cube.transform.gameObject);
    }
}
