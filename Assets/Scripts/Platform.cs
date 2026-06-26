using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _minDisappearanceTime;
    [SerializeField] private float _maxDisappearanceTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Cube cube) && cube.IsPlatformTouched == false)
        {
            cube.ChangeColorToRandom();
            cube.SetPlatformTouched();
            cube.SetTimeOfLife(Random.Range(_minDisappearanceTime, _maxDisappearanceTime));

            StartCoroutine(ReturnCube(cube));
        }
    }

    private IEnumerator ReturnCube(Cube cube)
    {
        yield return new WaitForSeconds(cube.TimeOfLife);

        _spawner.ReleaseCube(cube);
    }
}
