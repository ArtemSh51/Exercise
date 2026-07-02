using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Signaling _signaling;

    private void OnEnable()
    {
        _collisionHandler.AreaCrossed += IncreaseAlarmVolume;
        _collisionHandler.AreaAbandoned += LowerAlarmVolume;
    }

    private void OnDisable()
    {
        _collisionHandler.AreaCrossed -= IncreaseAlarmVolume;
        _collisionHandler.AreaAbandoned -= LowerAlarmVolume;
    }

    private void IncreaseAlarmVolume()
    {
        _signaling.IncreaseVolume();
    }

    private void LowerAlarmVolume()
    {
        _signaling.ReduceAlarmVolume();
    }
}
