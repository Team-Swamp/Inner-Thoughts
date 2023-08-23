using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    
    private Rigidbody2D _rigidbody;
    private Vector2 _moveVelocity;

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    private void FixedUpdate() => SetMoveDirection();

    private void GetInput(out Vector2 input2D)
    {
        input2D.x = Input.GetAxisRaw("Horizontal");
        input2D.y = Input.GetAxisRaw("Vertical");
    } 
    
    private void SetMoveDirection()
    {
        GetInput(out var movementInput);
        
        _moveVelocity = movementInput * movingSpeed * Time.deltaTime;
        _rigidbody.velocity = _moveVelocity;
    }
}
