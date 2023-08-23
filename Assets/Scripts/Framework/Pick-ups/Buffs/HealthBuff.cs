using UnityEngine;

public class HealthBuff : MonoBehaviour, IPickup
{
    [SerializeField] private float buffHealthAmount;
    
    public void Pickup(GameObject player)
    {
        player.GetComponent<HealthData>().BuffHealth(buffHealthAmount);
        Destroy(gameObject);
    }
}
