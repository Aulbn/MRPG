using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class PlayerMovement : MonoBehaviour
{
    public PlayerAnimationHandler animHandler;
    private CharacterController cc;

    [Header("Movement")]
    public float normalSpeed;
    public float runSpeed;
    public float accelerationTime = 0.1f;
    public float turnSmoothTime = 0.1f;
    public float gravity = 18f;

    public Vector3 Velocity { get; set; }
    public float MovementSpeed { get; private set; }
    public bool PlayerInControl { get { return MovementLocks <= 0; } }
    public int MovementLocks { get; private set; }

    private float speedSmoothVelocity;
    private float turnSmoothVelocity;
    private float currentSpeed;
    private Vector2 movementInput;
    private bool isInCombat = false;
    private bool isSprinting = false;


    [Header("Body")]
    public Collider playerCollider;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Start()
    {
        MovementSpeed = normalSpeed;
    }

    private void Update()
    {
        MovementUpdate();
        RotationUpdate();
    }

    public void OnMovement(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    public void SetMovement(Vector2 input)
    {
        movementInput = input;
    }

    private void MovementUpdate()
    {
        if (cc.isGrounded && PlayerInControl)
        {
            if (isInCombat)
            {
                //Velocity = Velocity.y * transform.up + (movementInput.y * transform.forward + movementInput.x * transform.right) * MovementSpeed;
                //animHandler.SetLocomotion(movementInput.x, movementInput.y);
            }
            else
            {
                currentSpeed = Mathf.SmoothDamp(currentSpeed, MovementSpeed * movementInput.magnitude, ref speedSmoothVelocity, accelerationTime);
                Velocity = Velocity.y * transform.up + (transform.forward) * currentSpeed;
                //animHandler.SetLocomotion(0, 0);

                animHandler.SetVelocity(currentSpeed / normalSpeed);
            }
        }
        else
            Velocity += Vector3.down * gravity * Time.deltaTime; //Gravity

        cc.Move(Velocity * Time.deltaTime); //Movement
        animHandler.SetIsGrounded(cc.isGrounded);
        //animHandler.SetMagnitude(new Vector3(Velocity.x, 0, Velocity.z).magnitude / MovementSpeed * (isSprinting ? 2 : 1));
    }

    public void EnterCombat(/*Enemy target*/)
    {
        isInCombat = true;
    }

    private void RotationUpdate()
    {
        if (!PlayerInControl) return;

        Vector2 inputDir = movementInput.normalized;

        if (isInCombat)
        {
            //float targetRot = Mathf.Atan2(0, 1) * Mathf.Rad2Deg + CameraController.Cam.transform.eulerAngles.y;
            //transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRot, ref turnSmoothVelocity, turnSmoothTime);
        }
        else
        {
            if (inputDir != Vector2.zero)
            {
                float targetRot = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + CameraController.Cam.transform.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRot, ref turnSmoothVelocity, turnSmoothTime);

                //SteepTurnCheck(targetRot);//180 degree turn if turning too steep when sprinting
            }
            else
            {
                if (isSprinting)
                    ToggleSprint(false);
            }
        }
    }

    private void ToggleSprint(bool value)
    {
        isSprinting = value;
        MovementSpeed = value ? normalSpeed : runSpeed;
    }

}
