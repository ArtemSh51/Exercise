using UnityEngine;

public class VampirismActionPoint : MonoBehaviour
{
    [SerializeField] private Player _pointIndicator;
    [SerializeField] private Vampirism _vampirism;

    private void Update()
    {
        Vector3 playerGazeDirection = -_pointIndicator.transform.right;

        transform.position = _pointIndicator.transform.position + playerGazeDirection * _vampirism.Radius;
    }
}
