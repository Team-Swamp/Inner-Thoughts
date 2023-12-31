using UnityEngine;
using UnityEngine.Events;

public sealed class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GunData startingGunData;
    [SerializeField] private Transform firePoint;

    [Header("Unity Event's")]
    [SerializeField] private UnityEvent onShoot = new UnityEvent();

    private GameObject _bullet;
    private float _shootingPower;
    private float _maxShootingDelay;
    private float _currentShootDelay;
    private bool _autoShooting;

    private void Awake() => SetGunData(startingGunData); 
    
    private void Update()
    {
        _currentShootDelay -= Time.deltaTime;
        if (_autoShooting && Input.GetButton("Fire1")) DelayedShooting();
        else if (Input.GetButtonDown("Fire1")) DelayedShooting();
    }

    public void SetGunData(GunData gunData)
    {
        _bullet = gunData.bullet;
        _shootingPower = gunData.shootingPower;
        _maxShootingDelay = gunData.shootingDelay;
        _currentShootDelay = _maxShootingDelay;
        _autoShooting = gunData.autoShooting;
    }

    private void DelayedShooting()
    {
        if (!(_currentShootDelay <= 0)) return;
        
        Shoot();
        _currentShootDelay = _maxShootingDelay;
    }

    private void Shoot()
    {
        var currentBullet = Instantiate(_bullet, transform.position, transform.rotation); //todo: rotation laten kloppen met de riching dat de bullet op gaat. (als de bullets niet rond zijn)
        currentBullet.GetComponent<Bullet>().ActiveBullet(ShootingDirection(), _shootingPower, "Enemy");

        onShoot?.Invoke();
    }

    private Vector2 ShootingDirection()
    {
        var firePointVector2 = new Vector2(firePoint.position.x, firePoint.position.y);
        var dir = MousePosition.GetMouseWorldPosition() - firePointVector2;
        return dir.normalized;
    }
}
