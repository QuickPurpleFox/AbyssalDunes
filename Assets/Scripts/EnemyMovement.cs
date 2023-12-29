using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    [SerializeField] 
    private Transform playerTransform;
    [SerializeField] 
    private String[] listOfActtion = {"stationary", "patrol"};
    
    private RaycastHit2D _ray;
    private LayerMask _mask;
    private Transform _transform;
    private Rigidbody2D _rb;
    private Animator _animator;
    
    void Start()
    {
        _mask = LayerMask.GetMask("PlayerLayer");
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(_transform.position, playerTransform.position);
        _ray = Physics2D.Raycast(transform.position, Vector2.right, 5f, _mask);
        
        Debug.DrawRay(_transform.position, Vector2.right * 5, Color.red);
        
        if (_ray.collider != null)
        {
            if (_ray.transform.tag == "Player")
            {
                _animator.CrossFade("Guard_Move_Right", 0, 0); //todo: change sprite
                _rb.velocity = new Vector2(1,0) * speed;
            }
        }
    }
}
