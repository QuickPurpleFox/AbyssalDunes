using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractHandler : MonoBehaviour
{
    private LayerMask _mask;
    private RaycastHit2D _ray;
    private InventroyObject _inventory;

    private void Start()
    {
        _inventory = GetComponent<PlayerInventoryHandler>().inventory;
    }

    void Update()
    {
        _ray = Physics2D.Raycast(transform.position - new Vector3(1,0), Vector2.right, 2f);
        Debug.DrawRay(transform.position - new Vector3(1,0), Vector2.right, Color.cyan);
        if (_ray.collider != null)
        {
            /*if (_ray.collider.gameObject.transform.CompareTag("NPC"))
            {
                Debug.Log("Can talk");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Interaction");
                }
            }*/

            if (_ray.collider.gameObject.transform.CompareTag("Doors"))
            {
                Debug.Log("Can Enter room");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Input.GetKeyDown(KeyCode.E) && SceneManager.GetActiveScene().name == "DesertScene")
                    {
                        SceneManager.LoadScene("Tavern");
                    }
                    else if(Input.GetKeyDown(KeyCode.E) && SceneManager.GetActiveScene().name == "Tavern")
                    {
                        SceneManager.LoadScene("DesertScene");
                    }
                }
            }
            
            if (_ray.collider.gameObject.transform.CompareTag("Portal"))
            {
                SceneManager.LoadScene("EndScene");    
            }

            if (_ray.collider.gameObject.transform.CompareTag("Item"))
            {
                Debug.Log("can pick up item");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    try
                    {
                        _inventory.AddItem(_ray.collider.GameObject().GetComponent<Item>().item, 1);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    Destroy(_ray.collider.GameObject());
                }
            }
        }
    }
}
