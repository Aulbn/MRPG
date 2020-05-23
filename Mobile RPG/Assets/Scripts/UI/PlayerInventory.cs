using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    public static PlayerInventory Instance;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public static void AddItem()
    {
        
    }

}
