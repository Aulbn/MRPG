using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private List<Item> content;
    private float size;

    public static void Spawn(Vector3 position, Item[] content, float size)
    {
        Pickable p = Instantiate(UIManager.LootInventory.bagPrefab, position, Quaternion.identity)
            .GetComponent<Pickable>();
        p.SetContent(content);
        p.size = size;
    }

    private void SetContent(Item[] content)
    {
        this.content = new List<Item>(content);
    }

    public void Open()
    {
        //Show inventory in UI
        Debug.Log("Open loot");
        UIManager.LootInventory.SetContent(content.ToArray(), 10);
        UIManager.LootInventory.Open();
        PlayerInventory.Open();
    }

    public void Destroy()
    {
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
        UIManager.LootInventory.Close();
    }
}
