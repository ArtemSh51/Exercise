using System;
using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField] private Transform _cube;
    [SerializeField] private CubeRecipient _recipient;

    [SerializeField, Min(0)] private float _forceImpulse;
    [SerializeField, Min(0)] private int _minCountOfCubes;
    [SerializeField, Min(0)] private int _maxCountOfCubes;

    public event Action<RaycastHit> CubesCreated;

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

    private void CreateNewCubes(RaycastHit hit)
    {
        Cube cube = hit.transform.GetComponent<Cube>();

        if (UnityEngine.Random.value <= cube.ChanceOfDivision)
        {
            float currentChanceOfDivision = cube.ChanceOfDivision;
            float reductionFactor = 2;

            for (int i = 0; i < UnityEngine.Random.Range(_minCountOfCubes, _maxCountOfCubes); i++)
            {
                Transform newCube = Instantiate(_cube, GetPositionOfCube(hit), Quaternion.identity);

                Vector3 directionOfPush = newCube.transform.position - hit.transform.position;

                newCube.GetComponent<Rigidbody>().AddForce(directionOfPush * _forceImpulse, ForceMode.Impulse);

                newCube.localScale = new Vector3(hit.transform.localScale.x / 2,
                                                 hit.transform.localScale.y / 2,
                                                 hit.transform.localScale.z / 2);

                newCube.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value,
                                                                            UnityEngine.Random.value,
                                                                            UnityEngine.Random.value);

                newCube.GetComponent<Cube>().SetChanceOfDivision(currentChanceOfDivision, reductionFactor);
            }
        }

        CubesCreated?.Invoke(hit);
    }

    private Vector3 GetPositionOfCube(RaycastHit hit)
    {
        float negativeAxis = -1;
        float positiveAxis = 1;

        float randomIncreaseToPosition = UnityEngine.Random.Range(negativeAxis, positiveAxis);

        return hit.transform.position + randomIncreaseToPosition * (hit.transform.right + hit.transform.forward).normalized;
    }
}
