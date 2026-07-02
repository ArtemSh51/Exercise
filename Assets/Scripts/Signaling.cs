using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private const float _maxVolume = 1;
    private const float _minVolume = 0;

    [SerializeField, Range(0.1f, 1)] private float _volumeDelta;

    private AudioSource _audio;

    private Coroutine _gradualIncreaseInVolume;
    private Coroutine _gradualReduceInVolume;

    private float _currentVolume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void IncreaseVolume()
    {
        _audio.Play();

        if (_gradualReduceInVolume != null)
        {
            StopCoroutine(_gradualReduceInVolume);

            _gradualReduceInVolume = null;
        }

        if (_gradualIncreaseInVolume == null)
        {
            _gradualIncreaseInVolume = StartCoroutine(IncreaseVolumeGradually());
        }
    }

    public void ReduceAlarmVolume()
    {
        if (_gradualIncreaseInVolume != null)
        {
            StopCoroutine(_gradualIncreaseInVolume);

            _gradualIncreaseInVolume = null;
        }

        if (_gradualReduceInVolume == null)
        {
            _gradualReduceInVolume = StartCoroutine(ReduceVolumeGradually());
        }
    }

    private void SetSoundVolume(float target)
    {
        _currentVolume = Mathf.MoveTowards(_currentVolume, target, _volumeDelta * Time.deltaTime);

        _audio.volume = _currentVolume;
    }

    private IEnumerator ReduceVolumeGradually()
    {
        while (_audio.volume > _minVolume)
        {
            SetSoundVolume(_minVolume);

            yield return null;
        }

        _audio.Stop();
    }

    private IEnumerator IncreaseVolumeGradually()
    {
        while (_audio.volume < _maxVolume)
        {
            SetSoundVolume(_maxVolume);

            yield return null;
        }
    }
}
