using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcHandler : MonoBehaviour
{
    private LayerMask _mask;
    private RaycastHit2D _ray;
    
    void Start()
    {
        _mask = LayerMask.GetMask("NPC");
    }
    
    void Update()
    {
        _ray = Physics2D.Raycast(transform.position, Vector2.right, 2f, _mask);
        if (_ray.collider != null)
        {
            Debug.Log("Can talk");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interaction");
            }
        }
    }
}
