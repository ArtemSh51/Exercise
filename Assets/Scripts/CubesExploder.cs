using System.Collections.Generic;
using UnityEngine;

public class CubesExploder : MonoBehaviour
{
    [SerializeField, Min(0)] private float _powerOfDiscardingCubes;

    [SerializeField, Range(10, 10000)] private int _maxCountOfObjectsInEnvironment;

    private Collider[] _cubes;

    private void Awake()
    {
        _cubes = new Collider[_maxCountOfObjectsInEnvironment];
    }

    public void ExplosionOfCreatedCubes(List<Cube> cubes, Cube cube)
    {
        foreach (Cube currentCube in cubes)
        {
            Vector3 directionOfPush = (currentCube.transform.position - cube.transform.position).normalized;

            if (currentCube.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddForce(directionOfPush * _powerOfDiscardingCubes, ForceMode.Impulse);
            }
        }
    }

    public void ExplosionOfPressedCube(Cube cube, float forceImpulse, float radius)
    {
        int countOfCubes = Physics.OverlapSphereNonAlloc(cube.transform.position, radius, _cubes);

        for (int i = 0; i < countOfCubes; i++)
        {
            Vector3 directionOfPush = (_cubes[i].transform.position - cube.transform.position);

            float distance = directionOfPush.magnitude;

            if (_cubes[i].TryGetComponent(out Rigidbody rigidbody) && distance != 0)
            {
                rigidbody.AddForce(directionOfPush.normalized * forceImpulse / distance, ForceMode.Impulse);
            }
        }
    }
}
