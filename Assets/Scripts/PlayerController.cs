using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected bool debugMode = false;
    [SerializeField] protected float torqueForce = 150f;
    [SerializeField] protected float maxAngularVelocity = 5f;
    [SerializeField] protected float acceleration = 100f;
    [SerializeField] protected float maxSpeed = 10f;

    protected Vector2 moveInput = Vector2.zero;
    protected Camera cam;
    protected Rigidbody rb;

    protected bool isGrounded;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update() 
    {
        checkGrounded();
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

    void checkGrounded()
    {
        Debug.DrawRay(transform.position, -Vector3.up * (GetComponent<Collider>().bounds.extents.y + 0.1f), Color.red);
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
    }
}
