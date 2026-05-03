using UnityEngine;

public class LocalMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }
}
