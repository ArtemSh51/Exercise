using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField, Delayed] private float _minDisappearanceTime;
    [SerializeField, Delayed] private float _maxDisappearanceTime;

    public event Action<Cube> PlatformTouched;

    private Renderer _renderer;
    private bool _isPlatformTouched;

    public float TimeOfLife { get; private set; }

    private void OnValidate()
    {
        if (_minDisappearanceTime >= _maxDisappearanceTime)
        {
            _maxDisappearanceTime = _minDisappearanceTime + 1;
        }
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Platform") && _isPlatformTouched == false)
        {
            ChangeColorToRandom();
            SetPlatformTouched();
            SetTimeOfLife(UnityEngine.Random.Range(_minDisappearanceTime, _maxDisappearanceTime));

            PlatformTouched?.Invoke(this);
        }
    }

    public void ChangeDefaultColor(Color defaultColor)
    {
        _renderer.material.color = defaultColor;
    }

    public void SetPlatformTouched()
    {
        _isPlatformTouched = _isPlatformTouched ? false : true;
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
    
    private void ChangeColorToRandom()
    {
        _renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }
}
