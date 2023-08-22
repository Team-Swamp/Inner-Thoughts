using UnityEngine;
using UnityEngine.Events;

public sealed class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GunData startingGunData;
    [SerializeField] private Transform firePoint;

    [Header("Unity Event's")]
    [SerializeField] private UnityEvent onShoot = new UnityEvent();
    
    private Bullet _bullet;
    private float _shootingPower;

    private void Awake() => SetGunData(startingGunData);

    private void Update()
    {
        if(Input.GetButtonDown("Fire1")) Shoot();
    }

    public void SetGunData(GunData targetData)
    {
        _bullet = targetData.bullet;
        _shootingPower = targetData.shootingPower;
    }

    private void Shoot()
    {
        var currentBullet = Instantiate(_bullet, transform.position, transform.rotation); //todo: rotation laten kloppen met de riching dat de bullet op gaat. (als de bullets niet rond zijn)
        currentBullet.ActiveBullet(ShootingDirection(), _shootingPower, "Enemy");

        onShoot?.Invoke();
    }

    private Vector2 ShootingDirection()
    {
        var firePointVector2 = new Vector2(firePoint.position.x, firePoint.position.y);
        var dir = MousePosition.GetMouseWorldPosition() - firePointVector2;
        return dir.normalized;
    }
}
