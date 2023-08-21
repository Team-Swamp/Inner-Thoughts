using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletStartAmount;
    [SerializeField] private List<Bullet> activeBullets = new List<Bullet>();
    [SerializeField] private List<Bullet> inactiveBullets = new List<Bullet>();

    private void Awake() => InitObjects();

    // bullet aan zetten
    public void StartBullet(Vector2 shootTarget, float shootingPower, string targetToHit)
    {
        if(inactiveBullets.Count == 0) CreateNewBullet();
        
        Debug.Log("1 inactive: " + inactiveBullets.Count + " active: " + activeBullets.Count);
        
        activeBullets.Add(inactiveBullets[0]);
        inactiveBullets.Remove(inactiveBullets[0]);
        
        Debug.Log("2 inactive: " + inactiveBullets.Count + " active: " + activeBullets.Count);
        
        activeBullets[activeBullets.Count].gameObject.SetActive(true);
        activeBullets[activeBullets.Count].ActiveBullet(shootTarget, shootingPower, targetToHit);
    }
    
    // bullet uit zetten
    public void ResetBullet()
    {
        inactiveBullets.Add(activeBullets[0]);
        activeBullets.Remove(activeBullets[0]);
    }
    
    // init objects
    private void InitObjects()
    {
        for (int i = 0; i < bulletStartAmount; i++)
        {
            CreateNewBullet();
        }
    }
    
    // bullet maken wanneer alle al zijn gebruikt
    private void CreateNewBullet()
    {
        var newBulletObject= Instantiate(bullet, transform);
        newBulletObject.SetActive(false);

        var newBullet = newBulletObject.GetComponent<Bullet>();
        newBullet.SetObjectPooling(this);
        inactiveBullets.Add(newBullet);
    }
}
