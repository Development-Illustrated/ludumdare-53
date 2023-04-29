using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBounce : MonoBehaviour
{

    [SerializeField] float bounceForce;
    [SerializeField] Vector3 bounceDirection;
    [SerializeField] bool debugMode;

    private void OnCollisionEnter(Collision other) 
    {
        if(debugMode){Debug.Log("Collision detected on IBounce");}

        if (other.gameObject.GetComponent<Rigidbody>() == null)
        {
            Debug.Log("IBounce tried bouncing something without a rigidbody.");
            return;
        }

        other.gameObject.GetComponent<Rigidbody>().AddForce(bounceDirection * bounceForce, ForceMode.Impulse);    
    }
}
