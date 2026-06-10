using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;

    public float ChanceOfDivision { get; private set; } = 1;

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
}
