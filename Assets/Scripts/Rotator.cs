using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rightAngle = 180;
    [SerializeField] private float _leftAngle = 0;

    public void TurnByY(float directionMove)
    {
        if (directionMove != 0)
        {
            if (directionMove > 0)
            {
                transform.rotation = Quaternion.Euler(0, _rightAngle, 0);
            }
            else if (directionMove < 0)
            {
                transform.rotation = Quaternion.Euler(0, _leftAngle, 0);
            }
        }
    }
}
