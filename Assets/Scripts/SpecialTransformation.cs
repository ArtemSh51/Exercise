using UnityEngine;

public class SpecialTransformation : MonoBehaviour
{
    [SerializeField] private float _speedOfMovement;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speedOfGrowth;

    private void Update()
    {
        transform.position += transform.right * _speedOfMovement * Time.deltaTime;

        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);

        transform.localScale += Vector3.one * _speedOfGrowth * Time.deltaTime;
    }
}
