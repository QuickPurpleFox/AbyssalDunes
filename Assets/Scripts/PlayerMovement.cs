using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    [SerializeField]
    private float speed = 4f;
    //private float _jumpingPower = 6f;
    private bool _isFacingRight = false;

    [SerializeField]
    private Rigidbody2D rb;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        _animator.SetFloat("Horizontal", horizontal);
        _animator.SetBool("IsFacingRight", _isFacingRight);
        Flip();
    }

    private void FixedUpdate()
    {
        InputHandler();
    }

    private void Flip()
    {
        if (_isFacingRight && horizontal < 0f || !_isFacingRight && horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
        }
    }

    private void InputHandler()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
}
