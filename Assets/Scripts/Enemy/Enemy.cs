using UnityEngine;

[RequireComponent(typeof(Patroler), typeof(Rotator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroler _patrol;
    [SerializeField] private Rotator _rotator;

    private void Awake()
    {
        _patrol = GetComponent<Patroler>();
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        _rotator.TurnByY(_patrol.Direction);
    }

    private void FixedUpdate()
    {
        _patrol.Move();
    }
}
