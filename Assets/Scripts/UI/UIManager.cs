﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private InventoryDisplay inventoryDisplay;
    [SerializeField] public HUD hud;
    [SerializeField] public Menu menu;

    public static InventoryDisplay InventoryDisplay { get { return Instance.inventoryDisplay; } }
    public static HUD HUD { get { return Instance.hud; } }
    public static Menu Menu { get { return Instance.menu; } }


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        menu.Close();
    }

    public void SetPause(bool pause)
    {
        if (pause)
            GameManager.PauseGame();
        else
            GameManager.UnpauseGame();

        hud.joystick.isEnabled = !pause;
    }

    public void TogglePause()
    {
        SetPause(Time.timeScale != 0);
    }

    public void ToggleHUD(bool enable)
    {
        hud.gameObject.SetActive(enable);
    }
}
