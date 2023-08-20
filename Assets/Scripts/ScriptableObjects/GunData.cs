using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject / Gun Data")]
public class GunData : ScriptableObject
{
    public GameObject bullet; //todo: maak dit naar een class
    [Range(0, 25)] public float shootingPower = 2;
}
