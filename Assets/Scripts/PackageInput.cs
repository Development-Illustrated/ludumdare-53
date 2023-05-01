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
        if(debugMode){Debug.Log("OnMove called");}
        this.gameObject.SendMessage("requestMove", value.Get<Vector2>());
    }

    public void OnJump()
    {
        if(debugMode){Debug.Log("OnJump Called");}
        this.gameObject.SendMessage("requestJump");
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

    public void OnRestartLevel()
    {
        if(debugMode){Debug.Log("OnRestartLevel called");}
        GameManager.gameManager.ReloadScene();
    }

    public void OnSubmit()
    {
        if(GameManager.gameManager.gameState == GameManager.GameState.Menu)
        {
            if(debugMode){Debug.Log("OnSubmit called");}
            GameManager.gameManager.ReloadScene();
        }
    }

    public void OnCancel()
    {
        if(GameManager.gameManager.gameState == GameManager.GameState.Menu)
        {
            if(debugMode){Debug.Log("OnCancel called");}
            GameManager.gameManager.LoadMainMenu();
        }
    }
}
