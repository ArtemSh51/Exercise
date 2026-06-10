using UnityEngine;

public class CubesExploder : MonoBehaviour
{
    [SerializeField, Min(0)] private float _forceImpulse;
    [SerializeField, Min(0)] private float _radius;

    [SerializeField] private CubeMaker _cubeMaker;

    private void OnEnable()
    {
        _cubeMaker.CubesCreated += BlowUp;
    }

    private void OnDisable()
    {
        _cubeMaker.CubesCreated -= BlowUp;
    }

    private void BlowUp(Cube cube)
    {
        Collider[] cubes = Physics.OverlapSphere(cube.transform.position, _radius);

        foreach (Collider currentCube in cubes)
        {
            Vector3 directionOfPush = (currentCube.transform.position - cube.transform.position).normalized;

            if (currentCube.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddForce(directionOfPush * _forceImpulse, ForceMode.Impulse);
            }
        }
    }
}
