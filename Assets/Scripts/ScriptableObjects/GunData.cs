using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject / Gun Data")]
public sealed class GunData : ScriptableObject
{
    [Header("Standard")]
    public GameObject bullet;
    [Range(0, 25)] public float shootingPower = 2;
    [Range(0, 1)] public float shootingDelay;
    
    [Header("Automatic")]
    public bool autoShooting;
}
