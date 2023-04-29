using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageController : MonoBehaviour
{
    Vector2 moveInput = Vector2.zero;
    Rigidbody rb;
    [SerializeField] float speed = 10f;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        move(moveInput.x, moveInput.y);
    }

    void move(float inputx, float inputy)
    {
        rb.AddTorque(new Vector3(inputx, 0, inputy) * speed, ForceMode.Force);
    }

    public void requestMove(Vector2 input)
    {
        moveInput = input;
    }
}
