using UnityEngine;

public sealed class ContactDamage : MonoBehaviour
{
    [SerializeField] private float damageNumber;

    [SerializeField] private HealthData healthData;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.HasTag("Enemy")) healthData.TakeDamage(damageNumber);
    }
}
