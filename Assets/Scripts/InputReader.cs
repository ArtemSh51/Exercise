using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action ButtonPressed;

    public bool IsCounterWorking {  get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsCounterWorking = IsCounterWorking ? false : true;

            ButtonPressed?.Invoke();
        }
    }
}
