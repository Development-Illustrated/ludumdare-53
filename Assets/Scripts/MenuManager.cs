using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string scenename;
    [SerializeField] bool debugMode;
    [SerializeField] PlayerInput playerInput;

    private void Awake() 
    {

    }
    public void OnPlayClicked()
    {
        if(debugMode){Debug.Log("Play button clicked");}
        SceneManager.LoadScene(scenename);
    }

    private void OnEnable() 
    {
        if(debugMode){Debug.Log("MenuManager enabled");}
        playerInput.SwitchCurrentActionMap("UI");
        GameManager.gameManager.gameState = GameManager.GameState.Menu;
    }

    private void OnDisable() 
    {
        if(debugMode){Debug.Log("MenuManager disabled");}
        playerInput.SwitchCurrentActionMap("Player");
        GameManager.gameManager.gameState = GameManager.GameState.Playing;
    }
}
