using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private List<Item> content;

    public static void Spawn(Vector3 position, Item[] content)
    {
        Instantiate(UIManager.Invetory.bagPrefab, position, Quaternion.identity)
            .GetComponent<Pickable>().SetContent(content);
    }

    private void SetContent(Item[] content)
    {
        this.content = new List<Item>(content);
    }

    public void Open()
    {
        //Show inventory in UI
        Debug.Log("Open loot");
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
    }
}
