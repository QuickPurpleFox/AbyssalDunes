using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    [SerializeField]
    private float speed = 4f;
    private bool _isFacingRight = false;
    private bool _isJumping = false;
    private bool _isInAir = false;
    private RaycastHit2D _ray;
    private LayerMask _groundMask;
    private bool _crawlFlag = false;
    
    public float raySize = 2;

    [SerializeField]
    private Rigidbody2D rb;
    private Animator _animator;
    private Transform _transform;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
        _groundMask = LayerMask.GetMask("Ground");
    }
    
    private void Update()
    {
        AnimatorHandler();
    }

    private void FixedUpdate()
    {
        InputHandler();
    }

    private void AnimatorHandler()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (_isFacingRight && horizontal < 0f || !_isFacingRight && horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
        }

        if (_isFacingRight  && !_isInAir)
        {
            if (horizontal > 0.5f)
            {
                _animator.CrossFade("PlayerRunRight", 0, 0);
            }
            else
            {
                _animator.CrossFade("PlayerIdleRight", 0, 0);
            }
        }
        else if(!_isInAir)
        {
            if (horizontal < -0.5f )
            {
                _animator.CrossFade("PlayerRunLeft", 0, 0);
            }
            else
            {
                _animator.CrossFade("PlayerIdleLeft", 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !_isInAir)
        {
            //spacja skok, jak is trigger to podciagniecie na dach
            _isJumping = true;
            _animator.CrossFade("PlayerJumpLeft", 0, 0);
        }
    }

    private void InputHandler()
    {
        Debug.DrawRay(transform.position, Vector2.down * raySize, Color.magenta);
        if (_isInAir)
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, raySize, _groundMask))
            {
                _isInAir = false;
            }
        }

        if (_crawlFlag)
        {
            return;
        }
        else if (!_isInAir && _isJumping)
        {
            rb.velocity = new Vector2(0, 6);
            _isJumping = !_isJumping;
            _isInAir = true;
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    public bool FacingRight()
    {
        return _isFacingRight;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.CompareTag("Roof"))
        {
            _crawlFlag = true;
            _animator.CrossFade("PlayerJumpIdleLeft",0 ,0);
            rb.position = new Vector2(_transform.position.x, 1.6f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.transform.CompareTag("Roof"))
        {
            _crawlFlag = false;
        }
    }
}
