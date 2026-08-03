using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthFingerSlider : MonoBehaviour
{
    [SerializeField] private float _smoothnessHealthFingerSlider;
    [SerializeField] private float _coroutineUpdateFrequency;

    private Slider _healthSlider;
    private float _currentHealthFingerSlider;
    private float _targetHealthFingerSlider;

    private Coroutine _coroutine;
    private bool _canUpdating = true;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    public void UpdateHealth(int maxHealth, int currentHealth)
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(UpdatingHealthFingerSlider());
        }

        _healthSlider.maxValue = maxHealth;

        if (currentHealth == maxHealth)
        {
            _currentHealthFingerSlider = maxHealth;
            _targetHealthFingerSlider = maxHealth;
        }

        _targetHealthFingerSlider = currentHealth;
    }

    private IEnumerator UpdatingHealthFingerSlider()
    {
        WaitForSeconds wait = new WaitForSeconds(_coroutineUpdateFrequency);

        while (_canUpdating)
        {
            _currentHealthFingerSlider = Mathf.MoveTowards(_currentHealthFingerSlider, _targetHealthFingerSlider, _smoothnessHealthFingerSlider);

            _healthSlider.value = _currentHealthFingerSlider;

            yield return wait;
        }
    }
}
