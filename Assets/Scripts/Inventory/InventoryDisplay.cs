using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    /*********************************************************************
    *                            DOKUMENTACJA                            *
    *   https://docs.unity3d.com/ScriptReference/Object.Instantiate.html *
    *                                                                    *
    **********************************************************************/
    
    private int _xColumn = 2;
    private int _yColumn = 2;

    [SerializeField]
    private float xSpaceBetweenColumn = 0.2f;
    [SerializeField]
    private float ySpaceBetweenColumn = 0.2f;

    private Dictionary<InventorySlot, GameObject> itemDisplay = new Dictionary<InventorySlot, GameObject>();

    [SerializeField] 
    private InventroyObject inventory;

    private void Start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        StartCoroutine(UpdateDisplay());
    }

    private void CreateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemDisplay.Add(inventory.container[i], obj);
        }
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(xSpaceBetweenColumn * (i % _xColumn), (-ySpaceBetweenColumn * (i /_yColumn)), 0f);
    }

    private IEnumerator  UpdateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            if (!itemDisplay.ContainsKey(inventory.container[i]))
            {
                var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                itemDisplay.Add(inventory.container[i], obj);
            }
            yield return null;
        }
    }
}


