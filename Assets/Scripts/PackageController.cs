using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageController : MonoBehaviour
{
    Vector2 moveInput = Vector2.zero;
    Camera camera;
    Rigidbody rb;
    [SerializeField] float speed = 10f;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
    }

    private void FixedUpdate() {
        move(moveInput.x, moveInput.y);
    }

    void move(float inputx, float inputy)
    {
        Vector3 targetDirection = new Vector3(inputy, 0f, -inputx);
        targetDirection = camera.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        rb.AddTorque(targetDirection * speed, ForceMode.Force);
    }

    public void requestMove(Vector2 input)
    {
        moveInput = input;
    }
}
