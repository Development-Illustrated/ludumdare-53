using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PackageInput : MonoBehaviour
{

    PackageController packageController;
    
    private void Awake() {
        packageController = GetComponent<PackageController>();
    }

    public void OnMove(InputValue value)
    {
        Debug.Log("OnMove called");
        packageController.requestMove(value.Get<Vector2>());
    }
}
