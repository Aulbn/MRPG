using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int slotCount = 40;
    public GameObject slotPrefab;
    public GameObject bagPrefab;

    [Header("References")]
    public Transform grid;

    public int Count { get; private set; }

    private List<InventorySlot> slots;
    private InventorySlot selectedSlot;


    private void Start()
    {
        slots = new List<InventorySlot>();
        for (int i = 0; i < slotCount; i++)
        {
            slots.Add(Instantiate(slotPrefab, grid).GetComponent<InventorySlot>());
        }
    }

    public bool AddItem(Item item)
    {
        if (Count >= slots.Count) return false;
        Count++;

        foreach(InventorySlot slot in slots)
        {
            if (slot.IsOccupied) continue;
            slot.SetItem(item);
            break;
        }

        Debug.Log("Added item");
        return true;
    }

    public void RemoveItem(Item item)
    {
        foreach(InventorySlot slot in slots)
        {
            if (slot.IsOccupied && slot.GetItem() == item)
                slot.RemoveItem();
        }

        Count--;
        //Sort items?
    }

    public void SelectSlot(InventorySlot slot)
    {
        if (selectedSlot != null) selectedSlot.Deselect();
        selectedSlot = slot;
    }


    public string SaveData()
    {
        return "";
    }

    public void LoadData(string data)
    {

    }
}
