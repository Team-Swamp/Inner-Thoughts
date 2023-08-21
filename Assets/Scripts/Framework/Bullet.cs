using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(0, 15)] private float despawnTime;
    
    private Rigidbody2D _rb;
    private string _playerTag = "Player";
    private string _enemyTag = "Enemy";
    private string _currentTargetToHit;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    public void ActiveBullet(Vector2 shootTarget, float shootingPower, string targetToHit)
    {
        _currentTargetToHit = targetToHit;
        
        _rb.velocity = shootTarget * shootingPower;
        StartCoroutine(Despawn());
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject.HasTag(_currentTargetToHit)) return;
        
        col.GetComponent<HealthData>().TakeDamage(1);
    }
}
