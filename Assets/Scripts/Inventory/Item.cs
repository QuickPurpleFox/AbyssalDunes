using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObject item;
    
    private void Awake()
    {
        Debug.Log("Awaken I Am ");
        Physics2D.queriesHitTriggers = true;
    }

    private void OnMouseDown()
    {
        Debug.Log("Item Clicked");
        if (item.type == ItemType.Potion)
        {
            Health.Instance.Heal(1);
        }
        DestroyGameObject();
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
