using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private CoinSpawner _spowner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPickable pickable))
        {
            pickable.PickUp();
        }

        if (collision.TryGetComponent(out IPickableWithPicker pickableWithPicker))
        {
            pickableWithPicker.PickUp(transform);
        }
    }
}
