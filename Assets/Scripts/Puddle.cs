using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    private PackageBehaviour player;


    public void OnTriggerEnter(Collider col) {
        Debug.Log("Entering Water");
        player = col.gameObject.GetComponent<PackageBehaviour>();
        player.setIsWet(true);
    }

    public void OnTriggerExit() {
        Debug.Log("Exiting Water");
        player.setIsWet(false);
    }
}

