using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int slotCount = 40;

    [Header("References")]
    public Transform content;

    public int Count { get; private set; }

    protected List<InventorySlot> slots;
    private InventorySlot selectedSlot;


    private void Awake()
    {
        slots = new List<InventorySlot>();
    }


    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void SetContent(Item[] items, int size)
    {
        slotCount = size;
        HideSlots();
        for (int i = 0; i < size; i++)
        {
            //Show slot
            if (content.childCount < i + 1)
                AddSlot();
            else
                slots[i].Show();

            //Set slot content
            if (i < items.Length)
                slots[i].SetItem(items[i]);
            else
                slots[i].Clear();
        }
    }

    private void HideSlots()
    {
        foreach (InventorySlot slot in slots)
        {
            slot.Hide();
        }
    }

    protected void AddSlot()
    {
        slots.Add(Instantiate(UIManager.LootInventory.slotPrefab, content).GetComponent<InventorySlot>());
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
            {
                slot.Clear();
                break;
            }
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
