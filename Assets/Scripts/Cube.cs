using UnityEngine;

public class Cube : MonoBehaviour
{
    public float ChanceOfDivision { get; private set; } = 1;

    public void SetChanceOfDivision(float currentChanceOfDivision, float reductionFactor)
    {
        ChanceOfDivision = currentChanceOfDivision / reductionFactor;
    }
}
