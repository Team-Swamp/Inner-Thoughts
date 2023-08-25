using UnityEngine;

public sealed class GunBuff : MonoBehaviour, IPickup
{
    [SerializeField] private GunData buffedGun;
    
    public void Pickup(GameObject player)
    {
        player.GetComponent<PlayerShooting>().SetGunData(buffedGun);
        Destroy(gameObject);
    }
}
