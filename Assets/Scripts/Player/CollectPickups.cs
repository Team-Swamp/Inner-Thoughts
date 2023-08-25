using UnityEngine;

public sealed class CollectPickups : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var collectible = col.GetComponent<IPickup>();
        collectible?.Pickup(gameObject);
    }
}
