using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PackageInput : MonoBehaviour
{
    [SerializeField] bool debugMode;

    PackageController packageController;
    
    private void Awake() {
        packageController = GetComponent<PackageController>();
    }

    public void OnMove(InputValue value)
    {
        if(debugMode)
        {
            Debug.Log("OnMove called");
        }
        
        packageController.requestMove(value.Get<Vector2>());
    }
}
