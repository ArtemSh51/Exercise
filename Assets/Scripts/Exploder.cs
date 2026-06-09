using System;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField, Min(0)] private float _forceImpulse;

    public event Action<RaycastHit> CubesExploded;

    public void BlowUp(RaycastHit hit)
    {
        Collider[] objectsWithColliders = Physics.OverlapSphere(hit.transform.position, 2);

        List<Cube> cubes = new List<Cube>();

        foreach(Collider objectWithColliders in objectsWithColliders)
        {
            if(objectWithColliders.TryGetComponent(out Cube cube) && cube.GetComponent<Rigidbody>() != null)
            {
                cubes.Add(cube);
            }
        }

        foreach (Cube cube in cubes)
        {
            Vector3 directionOfPush = cube.transform.position - hit.transform.position;

            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();
            rigidbody.AddForce(directionOfPush * _forceImpulse, ForceMode.Impulse);
        }

        CubesExploded?.Invoke(hit);
    }
}
