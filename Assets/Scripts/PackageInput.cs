using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PackageInput : MonoBehaviour
{
    [SerializeField] bool debugMode;

    PackageController packageController;
    ControllerManager controllerManager;
    
    private void Awake() {
        packageController = GetComponent<PackageController>();
        controllerManager = GetComponent<ControllerManager>();
    }

    public void OnMove(InputValue value)
    {
        if(debugMode)
        {
            Debug.Log("OnMove called");
        }
        
        this.gameObject.SendMessage("requestMove", value.Get<Vector2>());
    }

    public void OnBuddahMode()
    {
        if(debugMode){Debug.Log("OnBuddahMode called");}
        controllerManager.SwitchController(ControllerManager.ControllerType.BuddahController);
    }

    public void OnPackageMode()
    {
        if(debugMode){Debug.Log("OnPackageMode called");}
        controllerManager.SwitchController(ControllerManager.ControllerType.PackageController);
    }
}
