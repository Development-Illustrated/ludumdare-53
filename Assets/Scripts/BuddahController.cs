using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddahController : PlayerController
{
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        rb.maxAngularVelocity = maxSpeed;
        move(this.moveInput.x, moveInput.y);
    }

    void move(float inputx, float inputy)
    {
        if(this.debugMode){Debug.Log("Buddah Move called with: " + inputx + " " + inputy);}
        Vector3 targetDirection = new Vector3(inputx, -1f, inputy);
        targetDirection = cam.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        rb.AddForce(targetDirection * acceleration, ForceMode.Acceleration);
    }

    private void OnEnable() {
        rb.freezeRotation = true;
    }

    private void OnDisable() {
        rb.freezeRotation = false;
    }

    // public void requestMove(Vector2 input)
    // {
    //     moveInput = input;
    // }

    // public void ShootUp(float jumpForce)
    // {
    //     GetComponent<Collider>().material.bounciness = 0.5f;
    //     rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    // }

    // public void increaseTorque()
    // {
    //     torqueForce *= 2;
    //     maxAngularVelocity *= 2; 
    // }

    // public void Reset()
    // {
    //     torqueForce = 150f;
    //     maxAngularVelocity = 5f;
    //     GetComponent<Collider>().material.bounciness = 0f;
    // }
}
