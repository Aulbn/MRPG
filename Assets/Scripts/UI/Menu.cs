using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
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

        InventoryDisplay.SimpleOpen();
        menuPanel.gameObject.SetActive(false);
        menuButton.SetIsActive(true);
        pauseButton.SetIsActive(false);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        InventoryDisplay.Close();
        UIManager.Instance.SetPause(false);
    }

    public void ToggleInventoryMenu()
    {
        if (InventoryDisplay.Instance.gameObject.activeSelf)
        {
            InventoryDisplay.Open();
            menuPanel.gameObject.SetActive(true);
        }else
        {
            InventoryDisplay.Close();
            menuPanel.gameObject.SetActive(false);
        }
    }
}
