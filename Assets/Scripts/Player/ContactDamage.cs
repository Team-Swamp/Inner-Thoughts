using UnityEngine;

public sealed class ContactDamage : MonoBehaviour
{
    [SerializeField] private float damageNumber;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.HasTag("Player")) col.GetComponent<HealthData>().TakeDamage(damageNumber);
    }
}
