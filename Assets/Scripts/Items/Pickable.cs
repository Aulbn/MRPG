using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private Item[] content;
    private float size;

    private void Start()
    {
        //if (content == null) content = new Item[0];
    }

    public static void Spawn(Vector3 position, Item[] content, float size)
    {
        Pickable p = Instantiate(InventoryDisplay.BagPrefab, position, Quaternion.identity)
            .GetComponent<Pickable>();
        p.SetContent(content);
        p.size = size;
    }

    public void SetContent(Item[] content)
    {
        this.content = content;
        if (content == null || content.Length < 1)
            Destroy();
    }

    public Item[] GetContent()
    {
        return content;
    }

    public void Open()
    {
        //Show inventory in UI
        Debug.Log("Open loot");
        InventoryDisplay.Open();
        InventoryDisplay.OpenLoot(this);
    }

    public void Destroy()
    {
        Player.Instance.GetComponent<PlayerInteraction>().RemovePickable(this);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Player.Instance.GetComponent<PlayerInteraction>().AddPickable(this);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            Player.Instance.GetComponent<PlayerInteraction>().RemovePickable(this);
        InventoryDisplay.CloseLoot();
    }
}
