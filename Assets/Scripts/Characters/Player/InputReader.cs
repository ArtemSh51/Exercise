using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const KeyCode KeyCodeJump = KeyCode.Space;

    [SerializeField] private KeyCode KeyCodeAttack = KeyCode.Mouse0;

    public event Action<bool> ButtonJumpPressed;
    public event Action ButtonAttackPressed;

    public void ProcessJumpInput(bool isGrounded)
    {
        if (Input.GetKeyDown(KeyCodeJump))
        {
            ButtonJumpPressed?.Invoke(isGrounded);
        }
    }

    public void ProcessAttackInput()
    {
        if (Input.GetKeyDown(KeyCodeAttack))
        {
            ButtonAttackPressed?.Invoke();
        }
    }

    public float GetHorizontalMovementValue()
    {
        return Input.GetAxisRaw(Horizontal);
    }

    public KeyCode GetKeyAttack()
    {
        return KeyCodeAttack;
    }
}