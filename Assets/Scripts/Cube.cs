using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField, Delayed] private float _minDisappearanceTime;
    [SerializeField, Delayed] private float _maxDisappearanceTime;

    public event Action<Cube> PlatformTouched;

    private Renderer _renderer;
    private bool _isPlatformTouched;

    private float _timeOfLife;

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
        if (collision.collider.GetComponent<Platform>() != null && _isPlatformTouched == false)
        {
            ChangeColorToRandom();
            SetPlatformTouched();
            SetTimeOfLife(UnityEngine.Random.Range(_minDisappearanceTime, _maxDisappearanceTime));

            StartCoroutine(WaitWhile(this));
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

        _timeOfLife = timeOfLife;
    }
    
    private void ChangeColorToRandom()
    {
        _renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private IEnumerator WaitWhile(Cube cube)
    {
        yield return new WaitForSeconds(_timeOfLife);

        PlatformTouched?.Invoke(this);
    }
}
