using UnityEngine;

public sealed class SpeedBuff : MonoBehaviour, IPickup
{
    [SerializeField] private float buffSpeedAmount = 100;
    
    public void Pickup(GameObject player)
    {
        player.GetComponent<PlayerMovement>().BuffSpeed(buffSpeedAmount);
        Destroy(gameObject);
    }
}
