using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool isFacingRight;
    private RaycastHit2D _ray;
    private int _rotate;
    private GameObject linkToGuard;
    private EnemyMovement _giveDamage;
    private Animator _animator;
    void Start()
    {
        isFacingRight = gameObject.GetComponent<PlayerMovement>()._isFacingRight;
        linkToGuard = GameObject.Find("Guard");
        _giveDamage = linkToGuard.GetComponent<EnemyMovement>();
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        _rotate = 1;
        if (!isFacingRight)
        {
            _rotate = -1;
        }
        _ray = Physics2D.Raycast(transform.position - new Vector3(0, 1), Vector2.right * _rotate, 3f);
        Debug.DrawRay(transform.position - new Vector3(0,-1), Vector2.right * _rotate, Color.grey);
        if (_ray.collider != null)
        {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _animator.CrossFade("PlayerAttackLeft",0,0);
                    try
                    {
                        Debug.Log("attack");
                        _giveDamage.TakeDamage();
                        _giveDamage.noticeThief = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            
        }
    }
}
