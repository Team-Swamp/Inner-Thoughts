using UnityEngine;

public sealed class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    
    private Vector2 _input;
    
    private void Update()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
        
        var walksSideWays = _input.x != 0;
        var walkingUp = _input.y < 0;
        sprite.flipX = _input.x < 0;
        
        animator.SetBool("isWalking", _input != Vector2.zero);
        animator.SetBool("WalkingSideWays", walksSideWays);
        animator.SetBool("WalkingUp", walkingUp);
    }
}
