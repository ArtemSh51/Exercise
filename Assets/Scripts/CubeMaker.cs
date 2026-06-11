using System.Collections.Generic;
using UnityEngine;

public class CubeMaker : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    [SerializeField, Min(0)] private int _minCountOfCubes;
    [SerializeField, Min(0)] private int _maxCountOfCubes;

    private void OnValidate()
    {
        if (_minCountOfCubes >= _maxCountOfCubes)
        {
            _maxCountOfCubes = _minCountOfCubes + 1;
        }
    }

    public List<Cube> CreateNewCubes(Cube cube)
    {
        List<Cube> cubes = new List<Cube>();

        float currentChanceOfDivision = cube.ChanceOfDivision;
        float reductionFactor = 2;

        float numberOfCubes = Random.Range(_minCountOfCubes, _maxCountOfCubes);

        for (int i = 0; i < numberOfCubes; i++)
        {
            Cube newCube = Instantiate(_cube, GetPositionOfCube(cube), Quaternion.identity);

            newCube.SetNewSize(cube);

            newCube.SetRandomColor();

            newCube.IncreaseForceImpulse(cube);

            newCube.IncreaseRadius(cube);

            newCube.SetChanceOfDivision(currentChanceOfDivision, reductionFactor);

            cubes.Add(newCube);
        }

        return cubes;
    }

    public void RemoveCube(Cube cube)
    {
        Destroy(cube.transform.gameObject);
    }

    private Vector3 GetPositionOfCube(Cube cube)
    {
        float negativeAxis = -1;
        float positiveAxis = 1;

        float randomIncreaseToPosition = Random.Range(negativeAxis, positiveAxis);

        return cube.transform.position + randomIncreaseToPosition * (cube.transform.right + cube.transform.forward).normalized;
    }
}
