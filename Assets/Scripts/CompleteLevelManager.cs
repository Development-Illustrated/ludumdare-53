using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevelManager : MonoBehaviour
{
    [SerializeField] bool debugMode = false;
    [SerializeField] GameObject winboi;
    [SerializeField] TheGreatBallSpaffing theGreatBallSpaffing;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(debugMode){Debug.Log("Player finished level!");}

            string fuckSwitchStatements = SceneManager.GetActiveScene().name;

            switch(fuckSwitchStatements)
            {
                case "Warehouse":
                    GameManager.gameManager.LoadWarehouse1();
                    break;
                case "Warehouse1":
                    GameManager.gameManager.LoadWarehouse2();
                    break;
                case "Warehouse2":
                    winboi.SetActive(true);
                    theGreatBallSpaffing.enabled = true;
                    break;
            }
        }
    }
}
