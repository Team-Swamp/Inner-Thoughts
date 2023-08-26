using System;
using UnityEngine;

public sealed class ContactDamage : HealthData
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float damageNumber;

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject)
        //TakeDamage(damageNumber);
    }
}
