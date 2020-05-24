using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private List<Pickable> pickables;

    private void Awake()
    {
        pickables = new List<Pickable>();
    }

    public void OpenPickable()
    {
        if (pickables.Count > 0)
            pickables[0].Open();
    }

    public void AddPickable(Pickable pickable)
    {
        pickables.Add(pickable);
        if (pickables.Count > 0)
            UIManager.Instance.hud.ToggleLootButton(true);
    }

    public void RemovePickable(Pickable pickable)
    {
        pickables.Remove(pickable);
        if (pickables.Count < 1)
            UIManager.Instance.hud.ToggleLootButton(false);
    }
}
