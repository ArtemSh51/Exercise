using System;
using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField] private Transform _cube;

    [SerializeField, Min(0)] private int _minCountOfCubes;
    [SerializeField, Min(0)] private int _maxCountOfCubes;

    public event Action<RaycastHit> CubesCreated;
    public event Action<RaycastHit> CreationFailed;

    private void OnValidate()
    {
        if (_minCountOfCubes >= _maxCountOfCubes)
        {
            _maxCountOfCubes = _minCountOfCubes + 1;
        }
    }

    public void CreateNewCubes(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out Cube cube) && UnityEngine.Random.value <= cube.ChanceOfDivision)
        {
            float currentChanceOfDivision = cube.ChanceOfDivision;
            float reductionFactor = 2;
            float divider = 2;

            for (int i = 0; i < UnityEngine.Random.Range(_minCountOfCubes, _maxCountOfCubes); i++)
            {
                Transform newCube = Instantiate(_cube, GetPositionOfCube(hit), Quaternion.identity);

                newCube.localScale = new Vector3(hit.transform.localScale.x / divider,
                                                 hit.transform.localScale.y / divider,
                                                 hit.transform.localScale.z / divider);

                newCube.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value,
                                                                            UnityEngine.Random.value,
                                                                            UnityEngine.Random.value);

                newCube.GetComponent<Cube>().SetChanceOfDivision(currentChanceOfDivision, reductionFactor);
            }

            CubesCreated?.Invoke(hit);
        }
        else
        {
            CreationFailed?.Invoke(hit);
        }
    }

    private Vector3 GetPositionOfCube(RaycastHit hit)
    {
        float negativeAxis = -1;
        float positiveAxis = 1;

        float randomIncreaseToPosition = UnityEngine.Random.Range(negativeAxis, positiveAxis);

        return hit.transform.position + randomIncreaseToPosition * (hit.transform.right + hit.transform.forward).normalized;
    }
}
