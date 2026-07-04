using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private CoinSpawner _spowner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Return();
        }
    }
}
