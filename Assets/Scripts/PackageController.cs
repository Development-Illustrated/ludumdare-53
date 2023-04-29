using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageController : MonoBehaviour
{
    Vector2 moveInput = Vector2.zero;
    Camera cam;
    Rigidbody rb;

    [SerializeField] float torqueForce = 150f;
    [SerializeField] float maxAngularVelocity = 5f;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        
        cam = Camera.main;
    }

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

    public void requestMove(Vector2 input)
    {
        moveInput = input;
    }

    public void ShootUp(float jumpForce)
    {
        GetComponent<Collider>().material.bounciness = 0.5f;
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    public void increaseTorque()
    {
        torqueForce *= 2;
        maxAngularVelocity *= 2; 
    }

    public void Reset()
    {
        torqueForce = 150f;
        maxAngularVelocity = 5f;
        GetComponent<Collider>().material.bounciness = 0f;
    }
}
