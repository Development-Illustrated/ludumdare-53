using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] string dialogueLine;
    [SerializeField] bool debugMode;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            if(debugMode){Debug.Log("Player entered NPC trigger.");}
            
            
            
        }
    }
}
