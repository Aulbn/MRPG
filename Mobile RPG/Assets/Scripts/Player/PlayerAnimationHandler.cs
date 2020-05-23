using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetVelocity(float velocity)
    {
        anim.SetFloat("Velocity", velocity);
    }

    public void SetIsGrounded(bool isGrounded)
    {
        anim.SetBool("IsGrounded", isGrounded);
    }
}
