using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    
    private CharacterController _characterController;
    private Vector2 _movementInput;
    private Vector2 _moveDirection;

    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void FixedUpdate() => SetMoveDirection();

    private void GetInput(out Vector2 input2D)
    {
        input2D = Vector2.zero;
        input2D = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void SetMoveDirection()
    {
        GetInput(out _movementInput);
        _moveDirection = (transform.right * _movementInput + transform.up * _movementInput) * movingSpeed;
        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}
