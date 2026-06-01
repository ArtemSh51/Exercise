using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action ButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ButtonPressed?.Invoke();
        }
    }
}
