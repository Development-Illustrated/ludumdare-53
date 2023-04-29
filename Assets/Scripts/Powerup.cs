using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] string powerupName;
    [SerializeField] string powerupDuration;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage(powerupName);
        GetComponent<AudioSource>().Play();
    }
}
