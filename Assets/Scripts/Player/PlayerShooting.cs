using UnityEngine;
using UnityEngine.Events;

public sealed class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GunData currentGunData;
    [SerializeField] private Transform firePoint;

    [Header("Unity Event's")]
    [SerializeField] private UnityEvent onShoot = new UnityEvent();

    private void Update()
    {
        if(Input.GetButtonDown("Fire1")) Shoot();
    }

    public void SetGunData(GunData targetData) => currentGunData = targetData;

    private void Shoot() //todo: object pulling?
    {
        var currentBullet = Instantiate(currentGunData.bullet, transform.position, transform.rotation); //todo: rotation laten kloppen met de riching dat de bullet op gaat. (als de bullets niet rond zijn)
        currentBullet.GetComponent<Bullet>().ActiveBullet(ShootingDirection(), currentGunData.shootingPower, "Enemy");

        onShoot?.Invoke();
    }

    private Vector2 ShootingDirection()
    {
        var firePointVector2 = new Vector2(firePoint.position.x, firePoint.position.y);
        var dir = MousePosition.GetMouseWorldPosition() - firePointVector2;
        return dir.normalized;
    }
}
