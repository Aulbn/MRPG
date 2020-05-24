using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public static InventoryDisplay Instance;

    public GameObject slotPrefab;
    public GameObject bagPrefab;

    [Header("References")]
    [SerializeField] private Inventory lootInventory;
    [SerializeField] private Inventory playerInventory;
    //[SerializeField] private Button takeLootButton;
    [SerializeField] private SingleToggle takeLootButton;

    public static Inventory LootInventory { get { return Instance.lootInventory; } }
    public static Inventory PlayerInventory { get { return Instance.playerInventory; } }
    public static GameObject BagPrefab { get { return Instance.bagPrefab; } }
    public static GameObject SlotPrefab { get { return Instance.slotPrefab; } }

    private InventorySlot selectedSlot;
    private Pickable activeLoot;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < playerInventory.slotCount; i++)
        {
            playerInventory.AddSlot();
        }
    }


    public void MoveSelectedLoot()
    {
        if (selectedSlot.inventory == lootInventory)
        {
            playerInventory.AddItem(selectedSlot.Clear());
        }
        else
        {
            lootInventory.AddItem(selectedSlot.Clear());
        }

        DeselectSlot();
    }

    public static void DeselectSlot()
    {
        if (Instance.selectedSlot == null) return;
        Instance.selectedSlot.Deselect();
        Instance.selectedSlot = null;
        Instance.takeLootButton.SetInteractable(false);
    }

    public static void SelectSlot(InventorySlot slot)
    {
        if (Instance.selectedSlot != null) Instance.selectedSlot.Deselect();
        Instance.selectedSlot = slot;
        Instance.takeLootButton.SetIsActive(slot.inventory == LootInventory);
        Instance.takeLootButton.SetInteractable(slot.IsOccupied);
    }

    public static void CloseLoot()
    {
        LootInventory.Close();
        if (Instance.activeLoot != null)
        {
            Instance.activeLoot.SetContent(LootInventory.GetContent());
            Instance.activeLoot = null;
        }

    }

    public static void OpenLoot(Pickable lootBag)
    {
        Instance.activeLoot = lootBag;
        LootInventory.SetContent(lootBag.GetContent(), 10);
        LootInventory.Open();
    }

    public static void SimpleOpen()
    {
        Instance.gameObject.SetActive(true);
        DeselectSlot();
    }

    public static void Open()
    {
        UIManager.Menu.Open();
        SimpleOpen();
    }

    public static void Close()
    {
        Instance.gameObject.SetActive(false);
        CloseLoot();
    }

}
