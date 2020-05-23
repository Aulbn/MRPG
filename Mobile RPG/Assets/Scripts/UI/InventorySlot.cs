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

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        standardColor = buttonImage.color;
        UpdateVisuals();
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
    }

    public Item GetItem()
    {
        return item;
    }

    public Item RemoveItem()
    {
        Item i = item;
        DestroyItem();
        return i;
    }

    public void DestroyItem()
    {
        item = null;
        IsOccupied = false;
    }

    public void Deselect()
    {
        buttonImage.color = standardColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.Invetory.SelectSlot(this);
        buttonImage.color = highlightedColor;
    }
}
