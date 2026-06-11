using UnityEngine;

public class Cube : MonoBehaviour
{
    private const int CoefficientOfChange = 2;

    [SerializeField, Min(1)] private float _forceImpulse;
    [SerializeField, Min(1)] private float _radius;

    private Renderer _renderer;

    public float ChanceOfDivision { get; private set; } = 1;

    public float ForceImpulse => _forceImpulse;

    public float Radius => _radius;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetChanceOfDivision(float currentChanceOfDivision, float reductionFactor)
    {
        ChanceOfDivision = currentChanceOfDivision / reductionFactor;
    }

    public void SetRandomColor()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void IncreaseForceImpulse(Cube cube)
    {
        _forceImpulse = cube.ForceImpulse * CoefficientOfChange;
    }

    public void IncreaseRadius(Cube cube)
    {
        _radius = cube.Radius * CoefficientOfChange;
    }

    public void SetNewSize(Cube cube)
    {
        transform.localScale = new Vector3(cube.transform.localScale.x / CoefficientOfChange,
                                           cube.transform.localScale.y / CoefficientOfChange,
                                           cube.transform.localScale.z / CoefficientOfChange);
    }
}
