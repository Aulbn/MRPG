using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color highlightedColor;
    private Color standardColor;

    [Header("References")]
    public Image image;

    private Image buttonImage;

    public bool IsOccupied { get; private set; }

    private Item item;
    public Inventory inventory { get; private set; }

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        standardColor = buttonImage.color;
        UpdateVisuals();
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateVisuals()
    {
        if (IsOccupied)
            image.sprite = item.sprite;

        image.enabled = IsOccupied;
    }

    public void SetItem(Item item)
    {
        this.item = item;
        IsOccupied = true;
        UpdateVisuals();
        Debug.Log("Set: " + item.name);
    }

    public Item GetItem()
    {
        return item;
    }

    public Item Clear()
    {
        Item i = item;
        DestroyItem();
        UpdateVisuals();
        inventory.Count--;
        return i;
    }

    private void DestroyItem()
    {
        item = null;
        IsOccupied = false;
    }

    public void Deselect()
    {
        buttonImage.color = standardColor;
    }

    public void Select()
    {
        InventoryDisplay.SelectSlot(this);
        buttonImage.color = highlightedColor;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Select();
    }
}
