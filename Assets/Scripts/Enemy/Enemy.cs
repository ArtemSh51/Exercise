using UnityEngine;

[RequireComponent(typeof(Patrol))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
    }

    private void FixedUpdate()
    {
        _patrol.Move();
    }
}
