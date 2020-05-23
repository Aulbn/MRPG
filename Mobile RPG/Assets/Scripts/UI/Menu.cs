using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private RectTransform inventoryPanel;
    [SerializeField] private RectTransform menuPanel;
    [SerializeField] private SingleToggle pauseButton;
    [SerializeField] private SingleToggle menuButton;

    //private void Start()
    //{
    //    Close();
    //}

    public void Open()
    {
        gameObject.SetActive(true);

        inventoryPanel.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
        menuButton.SetIsActive(true);
        pauseButton.SetIsActive(false);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        UIManager.Instance.SetPause(false);
    }

    public void ToggleInventoryMenu()
    {
        bool inv = inventoryPanel.gameObject.activeSelf;
        inventoryPanel.gameObject.SetActive(!inv);
        menuPanel.gameObject.SetActive(inv);
    }
}
