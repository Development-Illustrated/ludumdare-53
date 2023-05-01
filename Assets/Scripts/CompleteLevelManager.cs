using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevelManager : MonoBehaviour
{
    [SerializeField] string scenename = "MainMenu";
    [SerializeField] bool debugMode = false;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(debugMode){Debug.Log("Player finished level!");}
            GameManager.gameManager.LoadMainMenu();
        }
    }
}
