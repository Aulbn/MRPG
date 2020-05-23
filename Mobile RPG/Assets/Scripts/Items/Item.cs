using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    [Header("Inventory")]
    public Sprite sprite;
    [HideInInspector] public int inventoryPosition;

    [Header("Stats")]
    public int buyPrice;
    public int sellPrice { get { return Mathf.RoundToInt(buyPrice * 0.75f); } }
}
