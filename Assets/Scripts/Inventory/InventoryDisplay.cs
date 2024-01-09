using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    /*********************************************************************
    *                            DOKUMENTACJA                            *
    *   https://docs.unity3d.com/ScriptReference/Object.Instantiate.html *
    *                                                                    *
    **********************************************************************/
    
    private int _xColumn;
    private int _yColumn;

    [SerializeField]
    private int xSpaceBetweenColumn;
    [SerializeField]
    private int ySpaceBetweenColumn;

    private Dictionary<InventorySlot, GameObject> itemDisplay = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void CreateDisplay()
    {
        
    }

    private void UpdateDisplay()
    {
        
    }
}


