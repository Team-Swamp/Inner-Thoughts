using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movingSpeed;


    private Vector2 _moveDirection;
    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        SetInput();
        SetMoveDirection();
    }

    private void SetInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    private void SetMoveDirection()
    {
        _moveDirection = (transform.right * _horizontal + transform.up * _vertical) * movingSpeed;
        characterController.Move(_moveDirection * Time.deltaTime);
    }
}
