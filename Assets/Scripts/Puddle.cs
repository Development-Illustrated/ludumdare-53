using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    private PackageBehaviour player;
    private IEnumerator coroutine;
    [SerializeField] float delay = 1f;
    [SerializeField] int dmg = 5;

    private void Awake() {
    }

    public void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player")
        {
            player = col.gameObject.GetComponent<PackageBehaviour>();
            coroutine = TakeDamage();
            StartCoroutine(coroutine);
        }
    }

    public void OnTriggerExit() {
        StopCoroutine(coroutine);
    }

    IEnumerator TakeDamage() {
        while(true) {
            player.PlayerTakeDmg(dmg, "water");
        
            Debug.Log("Taking damage");
            yield return new WaitForSeconds(delay);
        }
    }
}

