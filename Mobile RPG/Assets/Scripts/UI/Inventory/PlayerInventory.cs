using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    public static PlayerInventory Instance;
    private Inventory inventory;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        inventory = this;
        slots = new List<InventorySlot>();
    }

    private void Start()
    {
        for (int i = 0; i < slotCount; i++)
        {
            AddSlot();
        }
    }

    public new static void Open()
    {
        UIManager.Menu.Open();
    }

    public new static void Close()
    {
        Instance.inventory.Close();
    }

    public new static void AddItem(Item item)
    {
        Instance.inventory.AddItem(item);
    }

}
