using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet; //todo: maak dit naar een class
    [SerializeField] private Transform firePoint;
    [SerializeField, Range(0, 25)] private float shootingPower = 2;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1")) Shoot();
    }

    private void Shoot()//todo: object pulling?
    {
        var currentBullet = Instantiate(bullet, transform.position, transform.rotation);//todo: rotation laten kloppen met de riching dat de bullet op gaat. (als de bullets niet rond zijn)
        var bulletRB = currentBullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = ShootingDirection() * shootingPower;
    }

    private Vector2 ShootingDirection()
    {
        var dir = MousePosition.GetMouseWorldPosition() - firePoint.position;
        return dir.normalized;
    }
}
