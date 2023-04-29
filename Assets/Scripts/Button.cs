using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject objectToEnable;

    private void OnCollisionEnter(Collision collision)
    {
        objectToEnable.SendMessage("TurnOn");
    }
}