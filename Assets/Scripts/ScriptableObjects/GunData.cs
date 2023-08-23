using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject / Gun Data")]
public sealed class GunData : ScriptableObject
{
    public GameObject bullet;
    [Range(0, 25)] public float shootingPower = 2;
}
