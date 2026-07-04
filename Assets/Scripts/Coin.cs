using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Action<Coin> Taken;

    public void Return()
    {
        Taken?.Invoke(this);
    }
}
