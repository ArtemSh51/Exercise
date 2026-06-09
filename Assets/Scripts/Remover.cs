using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField] private Creater _creater;

    private void OnEnable()
    {
        _creater.CubesCreated += RemoveCube;
    }

    private void OnDisable()
    {
        _creater.CubesCreated -= RemoveCube;
    }

    private void RemoveCube(RaycastHit hit)
    {
        Destroy(hit.transform.gameObject);
    }
}
