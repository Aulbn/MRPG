using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    [SerializeField] private RectTransform joystickArea;
    [SerializeField] private RectTransform joystickOrigin;
    [SerializeField] private RectTransform joystick;
    [Space]
    public float range = 10f;

    [HideInInspector] public bool isEnabled = true;
    [HideInInspector] public bool isActive = false;

    private Vector2 originPos;


    private void Start()
    {
        HideJoystick();
    }

    private void Update()
    {
        if (!isEnabled) return;


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (joystickArea.rect.Contains(joystickArea.InverseTransformPoint(Input.mousePosition)))
            {
                ShowJoystick(Input.mousePosition);
            }
        } else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            HideJoystick();
        }

        if (isActive)
        {
            UpdateJoystick();
        }


    }

    private void UpdateJoystick()
    {
        Vector3 allowedPos = Input.mousePosition - joystickOrigin.position;
        allowedPos = Vector3.ClampMagnitude(allowedPos, (range * Screen.width));
        joystick.position = joystickOrigin.position + Vector3.ClampMagnitude(Input.mousePosition - joystickOrigin.position, (range * Screen.width));

        Player.Movement.SetMovement(allowedPos.normalized * allowedPos.magnitude / (range * Screen.width));
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
        isActive = enable;
        joystickOrigin.gameObject.SetActive(enable);
        Player.Movement.SetMovement(Vector2.zero);
    }

    public void SetAvailable(bool enable)
    {
        isEnabled = enable;
        isActive = enable ? isActive : false;
    }
}
