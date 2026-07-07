using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rightAngle = 180;
    [SerializeField] private float _leftAngle = 0;

    private Quaternion _rightTurn;
    private Quaternion _leftTurn;

    private void Awake()
    {
        _rightTurn = Quaternion.Euler(0, _rightAngle, 0);
        _leftTurn = Quaternion.Euler(0, _leftAngle, 0);
    }

    public void TurnByY(float directionMove)
    {
        if (directionMove != 0)
        {
            if (directionMove > 0)
            {
                transform.rotation = _rightTurn;
            }
            else if (directionMove < 0)
            {
                transform.rotation = _leftTurn;
            }
        }
    }
}
