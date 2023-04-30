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
}
