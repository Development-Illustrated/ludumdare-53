using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] string dialogueLine;
    [SerializeField] bool debugMode;

    [SerializeField] GameObject dialogueBox;
    [SerializeField] TypeWriterEffect typeWriterEffect;
    private void Start() 
    {
        dialogueBox.SetActive(false);
        typeWriterEffect.fullText = dialogueLine;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            if(debugMode){Debug.Log("Player entered NPC trigger.");}
            dialogueBox.SetActive(true);
            typeWriterEffect.StartText();
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            if(debugMode){Debug.Log("Player exited NPC trigger.");}
            dialogueBox.SetActive(false);
            typeWriterEffect.Clear();
        }
    }
}
