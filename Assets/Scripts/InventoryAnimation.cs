using System;
using UnityEngine;

public class InventoryAnimation : MonoBehaviour
{
    private Animator _animator;
    private String _animState;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animState = "InventoryClose";
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ChangeAnimatorState();
        }
    }

    void ChangeAnimatorState()
    {
        print("Should change");
        if (_animState == "InventoryClose")
        {
            _animator.Play("InventoryOpen");
            _animState = "InventoryOpen";
        }
        else
        {
            _animator.Play("InventoryClose");
            _animState = "InventoryClose";
        }
    }
}
