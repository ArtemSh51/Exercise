using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private const float _maxVolume = 1;
    private const float _minVolume = 0;

    [SerializeField, Range(0.1f, 1)] private float _volumeDelta;

    private AudioSource _audio;

    private bool _isInside;

    private float _currentVolume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isInside == false)
        {
            SetSoundVolume(_minVolume);

            if (_audio.volume == _minVolume)
            {
                _audio.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief _))
        {
            _isInside = true;

            _audio.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Thief _))
        {
            SetSoundVolume(_maxVolume);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief _))
        {
            _isInside = false;
        }
    }

    private void SetSoundVolume(float target)
    {
        _currentVolume = Mathf.MoveTowards(_currentVolume, target, _volumeDelta * Time.deltaTime);

        _audio.volume = _currentVolume;
    }
}
