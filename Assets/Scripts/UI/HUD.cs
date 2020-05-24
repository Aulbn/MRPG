using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public Joystick joystick;

    [Header("ButtonArea")]
    [SerializeField] private RectTransform buttonArea;
    [SerializeField] private TimerButton attackButton;
    [SerializeField] private TimerButton lootButton;

    private void Start()
    {
        ToggleLootButton(false);
    }

    public void OnLoot()
    {
        Player.Interaction.OpenPickable();
    }

    public void ToggleLootButton(bool enable)
    {
        if (lootButton.gameObject.activeSelf != enable)
            lootButton.gameObject.SetActive(enable);
    }

    public void SetButtonAreaVisible(bool isVisible)
    {
        buttonArea.gameObject.SetActive(isVisible);
    }

    public void AttackButton()
    {
        Debug.Log("Attack!");
    }
}
