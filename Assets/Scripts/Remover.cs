using UnityEngine;

public class Remover : MonoBehaviour
{
    public void RemoveCube(RaycastHit hit)
    {
        Destroy(hit.transform.gameObject);
    }
}
