using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageBehaviour : MonoBehaviour
{
    [SerializeField] HealthBar _healthbar;
    [SerializeField] bool isPowerupActive;
    [SerializeField] float powerupTimeout;
    [SerializeField] float powerupInitiated;
    [SerializeField] GameObject drybox;
    [SerializeField] GameObject soggybox;
    [SerializeField] GameObject fucked;

    PackageController playerController;
    AudioPlayer audioPlayer;
    

    private void Awake()
    {
        drybox.SetActive(true);
        soggybox.SetActive(false);
        playerController = GetComponent<PackageController>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    void Update()
    {
        if(isPowerupActive && (Time.time > powerupInitiated + powerupTimeout))
        {
            Reset();
        }
    }

    public void PlayerTakeDmg(int dmg, string dmgType)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
        if(_healthbar != null)
        {
            _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);

            if(GameManager.gameManager._playerHealth.Health <= 0)
            {
                fucked.SetActive(true);
            }
        }

        if(dmgType == "water" && GameManager.gameManager._playerHealth.Health < 70)
        {
            switchToSoggy();
        }
    }

    private void switchToSoggy()
    {
        Debug.Log("Box is soggy!");
        drybox.SetActive(false);
        soggybox.SetActive(true);
    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
        if(_healthbar != null)
        {
            _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
        }
    }

    public void Zoomies()
    {
        if (!isPowerupActive)
        {
            isPowerupActive = true;
            powerupInitiated = Time.time;
            powerupTimeout = 10f;
            playerController.increaseTorque();
        }
    }

    public void Fireworks()
    {
        if (!isPowerupActive)
        {
            isPowerupActive = true;
            powerupInitiated = Time.time;
            powerupTimeout = 10f;
            playerController.ShootUp(100f);
        }
    }

    public void Reset()
    {
        playerController.Reset();
        isPowerupActive = false;
        powerupInitiated = 0f;
        powerupTimeout = 0f;
    }

    private void OnCollisionEnter(Collision other) 
    {
        audioPlayer.playRandomOneShot();
    }
}
