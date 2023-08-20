using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    
    private CharacterController _characterController;
    private Vector2 _moveVelocity;

    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void FixedUpdate() => SetMoveDirection();

    private void GetInput(out Vector2 input2D)
    {
        input2D.x = Input.GetAxisRaw("Horizontal");
        input2D.y = Input.GetAxisRaw("Vertical");
    } 
    
    private void SetMoveDirection()
    {
        GetInput(out var _movementInput);
        
        _moveVelocity = (_movementInput + _movementInput) * movingSpeed;
        _characterController.Move(_moveVelocity * Time.deltaTime);
    }
}
