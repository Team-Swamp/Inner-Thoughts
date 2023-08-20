using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet; //todo: maak dit naar een class
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform testClickPoint;
    [SerializeField, Range(0, 25)] private float shootingPower = 2;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1")) Shoot();
    }

    private void Shoot()
    {
        var currentBullet = Instantiate(bullet, transform.position, transform.rotation); //todo: object pulling
        var bulletRB = currentBullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = ShootingDirection() * shootingPower;
    }

    private Vector2 ShootingDirection()
    {
        var dir = testClickPoint.position - firePoint.position;
        return dir.normalized;
    }
}
