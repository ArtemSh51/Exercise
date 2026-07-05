using System;
using UnityEngine;

public class Inputer : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public event Action ButtonPressed;

    public void PressButtonJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonPressed?.Invoke();
        }

    }

    public float GetHorizontalMovementValue()
    {
        return Input.GetAxisRaw(Horizontal);
    }
}
