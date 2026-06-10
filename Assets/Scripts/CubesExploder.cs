using System.Collections.Generic;
using UnityEngine;

public class CubesExploder : MonoBehaviour
{
    [SerializeField, Min(0)] private float _powerOfDiscardingCubes;
    [SerializeField, Min(0)] private float _forceImpulse;

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

    public void ExplosionOfPressedCube(Cube cube)
    {
        Collider[] cubes = Physics.OverlapSphere(cube.transform.position, 20);

        foreach (Collider currentCube in cubes)
        {
            Vector3 directionOfPush = (currentCube.transform.position - cube.transform.position);

            float distance = directionOfPush.magnitude;

            if (currentCube.TryGetComponent(out Rigidbody rigidbody) && distance != 0)
            {
                rigidbody.AddForce(directionOfPush.normalized * _forceImpulse / distance, ForceMode.Impulse);
            }
        }
    }
}
