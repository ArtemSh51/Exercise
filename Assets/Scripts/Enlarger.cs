using UnityEngine;

public class Enlarger : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.localScale += Vector3.one * _speed * Time.deltaTime;
    }
}
