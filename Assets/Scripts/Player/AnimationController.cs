using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    
    private Vector2 _input;
    
    private void Update()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
        
        animator.SetBool("isWalking", _input != Vector2.zero);
        animator.SetFloat("X", _input.x);
        animator.SetFloat("Y", _input.y);

        sprite.flipX = _input.x > 0;
    }
}
