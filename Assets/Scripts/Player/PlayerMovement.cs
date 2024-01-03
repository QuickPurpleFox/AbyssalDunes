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

        if (_isFacingRight)
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
        else
        {
            if (horizontal < -0.5f)
            {
                _animator.CrossFade("PlayerRunLeft", 0, 0);
            }
            else
            {
                _animator.CrossFade("PlayerIdleLeft", 0, 0);
            }
        }
    }

    private void InputHandler()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public bool FacingRight()
    {
        return _isFacingRight;
    }
}
