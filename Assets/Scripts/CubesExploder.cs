using System.Collections.Generic;
using UnityEngine;

public class CubesExploder : MonoBehaviour
{
    [SerializeField, Min(0)] private float _forceImpulse;
    [SerializeField, Min(0)] private float _radius;

    public void BlowUp(List<Cube> cubes, Cube cube)
    {
        foreach (Cube currentCube in cubes)
        {
            Vector3 directionOfPush = (currentCube.transform.position - cube.transform.position).normalized;

            if (currentCube.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddForce(directionOfPush * _forceImpulse, ForceMode.Impulse);
            }
        }
    }
}
