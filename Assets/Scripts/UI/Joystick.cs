using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform joystickArea;
    [SerializeField] private RectTransform joystickOrigin;
    [SerializeField] private RectTransform joystick;
    [Space]
    public float range = 10f;

    [HideInInspector] public bool isEnabled = true;
    //[HideInInspector] public bool isActive = false;

    private Vector2 originPos;
    private int touchIndex;

    private void Start()
    {
        HideJoystick();
    }

    private void Update()
    {
        if (!isEnabled) return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = new Vector3(eventData.position.x, eventData.position.y);
        Vector3 allowedPos = pos - joystickOrigin.position;
        allowedPos = Vector3.ClampMagnitude(allowedPos, (range * Screen.width));
        joystick.position = joystickOrigin.position + Vector3.ClampMagnitude(pos - joystickOrigin.position, (range * Screen.width));

        Player.Movement.SetMovement(allowedPos.normalized * allowedPos.magnitude / (range * Screen.width));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ShowJoystick(eventData.pressPosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        HideJoystick();
    }

    private void ShowJoystick(Vector2 joystickPosition)
    {
        ToggleJoystick(true);
        joystickOrigin.position = joystickPosition;
    }

    private void HideJoystick()
    {
        ToggleJoystick(false);
    }

    private void ToggleJoystick(bool enable)
    {
        //isActive = enable;
        joystickOrigin.gameObject.SetActive(enable);
        Player.Movement.SetMovement(Vector2.zero);
    }

    public void SetAvailable(bool enable)
    {
        isEnabled = enable;
        if (!enable)
            HideJoystick();
        //isActive = enable ? isActive : false;
    }
}
