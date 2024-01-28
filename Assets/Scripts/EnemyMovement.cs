using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool noticeThief;
    
    private int _health = 2;
    
    [SerializeField]
    private float speed = 3.5f;
    [SerializeField] 
    private float borderRight;
    [SerializeField] 
    private float borderLeft;
    
    private RaycastHit2D _ray;
    private LayerMask _mask;
    private Transform _transform;
    private Rigidbody2D _rb;
    private Animator _animator;
    private int _rotate;
    private bool _collisionEnter;
    
    void Start()
    {
        _mask = LayerMask.GetMask("PlayerLayer");
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _rotate = 1;
        _animator.CrossFade("Guard_IdleRight", 0, 0);
        noticeThief = false;
        _collisionEnter = false;
    }
    
    void Update()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
        _ray = Physics2D.Raycast(transform.position, Vector2.right * _rotate, 5f, _mask);
        
        Debug.DrawRay(_transform.position, Vector2.right * (_rotate * 5), Color.red);
        
        if (_ray.collider != null && noticeThief && !_collisionEnter)
        {
            if (_ray.transform.CompareTag("Player"))
            {
                if (_rotate == 1)
                {
                    _animator.CrossFade("Guard_RunRight", 0, 0);
                    _rb.velocity = new Vector2(1,0) * speed;
                }
                else
                {
                    _animator.CrossFade("Guard_RunLeft", 0, 0);
                    _rb.velocity = new Vector2(-1,0) * speed;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && noticeThief)
        {
            if (_rotate == 1)
            {
                _animator.CrossFade("Guard_AttackRight", 0, 0);
            }
            else
            {
                _animator.CrossFade("Guard_AttackLeft", 0, 0);
            }
            _collisionEnter = true;
            print("HitPlayer");
            Health.Instance.TakeDamage(1);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _ = other;
        _collisionEnter = false;
    }

    public void TakeDamage()
    {
        _health = _health - 1;
    }
}
