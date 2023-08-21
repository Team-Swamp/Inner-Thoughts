using System;
using Unity.VisualScripting;
using UnityEngine;

public sealed class Bullet : MonoBehaviour
{
    [SerializeField, Range(0, 150)] private float maxTravelDistance;
    
    private Rigidbody2D _rb;
    private string _playerTag = "Player";
    private string _enemyTag = "Enemy";
    private string _currentTargetToHit;
    private Vector2 _shootTarget;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        if(Despawn()) Destroy(gameObject);
    }

    public void ActiveBullet(Vector2 shootTarget, float shootingPower, string targetToHit)
    {
        _currentTargetToHit = targetToHit;
        _shootTarget = shootTarget;

        _rb.velocity = _shootTarget * shootingPower;
    }

    private bool Despawn()
    {
        var currentPosition = new Vector2(transform.position.x, transform.position.y);
        var distance = currentPosition - _shootTarget;
        return MathF.Abs(distance.magnitude) >= maxTravelDistance;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject.HasTag(_currentTargetToHit)) return;
        
        col.GetComponent<HealthData>().TakeDamage(1);
    }
}
