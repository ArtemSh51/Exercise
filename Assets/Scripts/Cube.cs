using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;

    public float TimeOfLife { get; private set; }

    public bool IsPlatformTouched { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void ChangeColorToRandom()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void ChangeDefaultCubColor(Color defaultColor)
    {
        _renderer.material.color = defaultColor;
    }

    public void SetPlatformTouched()
    {
        IsPlatformTouched = IsPlatformTouched ? false : true;
    }

    public void SetTimeOfLife(float timeOfLife)
    {
        if (timeOfLife < 0)
        {
            timeOfLife = 0;

            Debug.LogError("„исло может быть только положительным числом!");
        }

        TimeOfLife = timeOfLife;
    }
}
