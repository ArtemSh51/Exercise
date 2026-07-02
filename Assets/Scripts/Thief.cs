using UnityEngine;

public class Thief : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speedOfMovement;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotationY = Input.GetAxisRaw(Horizontal) * _rotationSpeed * Time.deltaTime;

        transform.Rotate(0, rotationY * _rotationSpeed, 0);
    }

    private void Move()
    {
        float move = Input.GetAxisRaw(Vertical);

        transform.position += transform.forward * move * _speedOfMovement * Time.deltaTime;
    }
}
