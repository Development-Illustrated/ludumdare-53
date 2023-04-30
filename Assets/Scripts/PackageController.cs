using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageController : PlayerController
{
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float flyingForce = 10f;
    [SerializeField] float additionalFallingForce = 1f;

    private void FixedUpdate()
    {
        rb.maxAngularVelocity = maxAngularVelocity;
        move(moveInput);
        airControl();
    }

    Vector3 getTargetDirection(float inputx, float inputy)
    {
        Vector3 targetDirection = new Vector3(inputx, 0f, inputy);
        targetDirection = cam.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        return targetDirection;
    }
    void move(Vector3 moveInput)
    {
        Vector3 targetDirection = getTargetDirection(moveInput.y, -moveInput.x);
        rb.AddTorque(targetDirection * torqueForce, ForceMode.Force);
    }

    void airControl()
    {
        if(!isGrounded)
        {
            Vector3 targetDirection = getTargetDirection(moveInput.x, moveInput.y);
            targetDirection.y = -additionalFallingForce;
            targetDirection *= flyingForce;
            rb.AddForce(targetDirection, ForceMode.Acceleration);
        }
    }

    public void requestJump()
    {
        if(isGrounded)
        {
            Vector3 targetDirection = getTargetDirection(moveInput.x, moveInput.y);
            targetDirection.y = 1f;
            targetDirection *= jumpForce;
            rb.AddForce(targetDirection, ForceMode.Impulse);
        }
    }
}
