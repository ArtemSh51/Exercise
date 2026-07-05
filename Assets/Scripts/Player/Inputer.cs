using System;
using UnityEngine;

public class Inputer : MonoBehaviour
{
    public event Action ButtonPressed;

    public void PressButtonJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonPressed?.Invoke();
        }
    }
}
