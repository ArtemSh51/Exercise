using UnityEngine;

[RequireComponent(typeof(Patroler))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroler _patrol;

    private void Awake()
    {
        _patrol = GetComponent<Patroler>();
    }

    private void FixedUpdate()
    {
        _patrol.Move();
    }
}
