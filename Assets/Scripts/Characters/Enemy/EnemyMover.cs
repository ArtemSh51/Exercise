using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rayLength;

    public void Move(float direction)
    {
        transform.position += Vector3.right * direction * _speed * Time.deltaTime;
    }
}
