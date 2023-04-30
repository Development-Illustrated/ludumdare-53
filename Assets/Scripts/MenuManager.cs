using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string scenename;
    [SerializeField] bool debugMode;

    public void OnPlayClicked()
    {
        if(debugMode){Debug.Log("Play button clicked");}
        SceneManager.LoadScene(scenename);
    }
}
