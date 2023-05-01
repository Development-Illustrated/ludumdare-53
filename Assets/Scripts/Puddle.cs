using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    private PackageBehaviour player;
    private IEnumerator coroutine;
    [SerializeField] float delay = 1f;
    [SerializeField] int dmg = 5;

    AudioPlayer audioPlayer;

    private void Awake() 
    {
        audioPlayer = GetComponent<AudioPlayer>();
    }

    public void OnCollisionEnter(Collision col) {
        Debug.Log("Collision with water");
        if(col.gameObject.tag == "Player")
        {
            audioPlayer.playRandomOneShot();
            player = col.gameObject.GetComponent<PackageBehaviour>();
            coroutine = TakeDamage();
            StartCoroutine(coroutine);
        }
    }

    public void OnCollisionExit() {
        Debug.Log("Stopped colliding with water");
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator TakeDamage() {
        while(true) {
            player.PlayerTakeDmg(dmg, "water");
        
            Debug.Log("Taking damage");
            yield return new WaitForSeconds(delay);
        }
    }
}

