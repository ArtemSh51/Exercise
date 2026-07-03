using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private const float _maxVolume = 1;
    private const float _minVolume = 0;

    [SerializeField, Range(0.1f, 1)] private float _volumeDelta;

    private AudioSource _audio;

    private Coroutine _coroutine;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void IncreaseVolume()
    {
        _audio.Play();

        ActivateCoroutine(_maxVolume);
    }

    public void ReduceAlarmVolume()
    {
        ActivateCoroutine(_minVolume);
    }

    private void ActivateCoroutine(float target)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ChangeVolumeGradually(target));
        }
    }

    private IEnumerator ChangeVolumeGradually(float target)
    {
        while (_audio.volume != target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, _volumeDelta * Time.deltaTime);

            yield return null;
        }

        if (_audio.volume == _minVolume)
        {
            _audio.Stop();
        }
    }
}
