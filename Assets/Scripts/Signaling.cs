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

    private Coroutine _gradualIncreaseInVolume;
    private Coroutine _gradualReduceInVolume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void IncreaseVolume()
    {
        _audio.Play();

        ActivateCoroutine(ref _gradualIncreaseInVolume, ref _gradualReduceInVolume, _maxVolume);
    }

    public void ReduceAlarmVolume()
    {
        ActivateCoroutine(ref _gradualReduceInVolume, ref _gradualIncreaseInVolume, _minVolume);

        if (_audio.volume == _minVolume)
        {
            _audio.Stop();
        }
    }

    private void ActivateCoroutine(ref Coroutine coroutineToStart, ref Coroutine coroutineToStop, float target)
    {
        if (coroutineToStop != null)
        {
            StopCoroutine(coroutineToStop);

            coroutineToStop = null;
        }

        if (coroutineToStart == null)
        {
            coroutineToStart = StartCoroutine(ChangeVolumeGradually(target));
        }
    }

    private IEnumerator ChangeVolumeGradually(float target)
    {
        while (_audio.volume != target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, _volumeDelta * Time.deltaTime);

            yield return null;
        }
    }
}
