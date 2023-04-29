using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageController : PlayerController
{
    private void FixedUpdate()
    {
        rb.maxAngularVelocity = maxAngularVelocity;
        move(moveInput.x, moveInput.y);
    }

    void move(float inputx, float inputy)
    {
        Vector3 targetDirection = new Vector3(inputy, 0f, -inputx);
        targetDirection = cam.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        rb.AddTorque(targetDirection * torqueForce, ForceMode.Force);
    }
}
