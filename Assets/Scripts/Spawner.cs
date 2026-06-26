using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _defaultCountOfCubes;
    [SerializeField] private int _size;

    [SerializeField, Delayed] private float _minX;
    [SerializeField, Delayed] private float _maxX;
    [SerializeField, Delayed] private float _minZ;
    [SerializeField, Delayed] private float _maxZ;
    [SerializeField] private float _height;
    [SerializeField] private float _deltaTime;

    private ObjectPool<Cube> _cubes;
    private bool _hasCheck = true;

    private void OnValidate()
    {
        if (_minX >= _maxX)
        {
            _maxX = _minX + 1;
        }

        if (_minZ >= _maxZ)
        {
            _maxZ = _minZ + 1;
        }
    }

    private void Awake()
    {
        _cubes = new ObjectPool<Cube>
        (
            createFunc: () =>
            {
                Cube cube = Instantiate(_cubePrefab);

                cube.PlatformTouched += ReturnCube;

                return cube;
            },

            actionOnGet: (cube) =>
            {
                cube.transform.position = new Vector3(Random.Range(_minX, _maxX + 1), _height, Random.Range(_minZ, _maxZ + 1));

                cube.gameObject.SetActive(true);
            },

            actionOnRelease: (cube) =>
            {
                ChangeStateOfCube(cube);
            },

            actionOnDestroy: (cube) =>
            {
                cube.PlatformTouched -= ReturnCube;

                Destroy(cube.gameObject);
            },

            collectionCheck: _hasCheck,
            defaultCapacity: _defaultCountOfCubes,
            maxSize: _size
        );
    }

    private void Start()
    {
        StartCoroutine(TakeCubeFromPool());
    }

    private void ChangeStateOfCube(Cube cube)
    {
        cube.ChangeDefaultColor(Color.white);

        cube.transform.position = Vector3.zero;

        cube.transform.rotation = Quaternion.identity;

        cube.gameObject.SetActive(false);

        cube.SetPlatformTouched();
    }

    private void ReturnCube(Cube cube)
    {
        _cubes.Release(cube);
    }

    private IEnumerator TakeCubeFromPool()
    {
        WaitForSeconds wait = new WaitForSeconds(_deltaTime);

        while (true)
        {
            Cube cube = _cubes.Get();

            yield return wait;
        }
    }
}