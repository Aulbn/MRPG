using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class SingleToggle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isActive;
    [SerializeField] string activeText;
    [SerializeField] Color activeTextColor;
    [SerializeField] Color activeColor;
    [SerializeField] string inactiveText;
    [SerializeField] Color inactiveTextColor;
    [SerializeField] Color inactiveColor;
    [Header("References")]
    [SerializeField] private Image graphics;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private UnityEvent onToggle;

    private bool isDown = false;

    private void Start()
    {
        if (text == null) GetComponentInChildren<TextMeshProUGUI>();
        if (graphics == null) GetComponent<Image>();

        SetIsActive(isActive);
    }

    public void Toggle()
    {
        SetIsActive(!isActive);
        InvokeEvents();
    }

    public void SetIsActive(bool isActive)
    {
        this.isActive = isActive;
        text.text = isActive ? activeText : inactiveText;
        text.color = isActive ? activeTextColor : inactiveTextColor;
        graphics.color = isActive ? activeColor : inactiveColor;
    }

    private void InvokeEvents()
    {
        onToggle.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDown)
        {
            Toggle();
        }
        isDown = false;
    }
}
