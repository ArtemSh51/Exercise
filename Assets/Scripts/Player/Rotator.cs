using UnityEngine;

public class Rotator : MonoBehaviour
{
    public void TurnByY(float directionMove)
    {
        if (directionMove != 0)
        {
            if (directionMove > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (directionMove < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
