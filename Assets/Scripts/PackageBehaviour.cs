using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageBehaviour : MonoBehaviour
{
    [SerializeField] HealthBar _healthbar;
    PackageController playerController;

    [SerializeField] bool isPowerupActive;
    [SerializeField] float powerupTimeout;
    [SerializeField] float powerupInitiated;

    private void Awake()
    {
        playerController = GetComponent<PackageController>();
    }

    void Update()
    {
        if(isPowerupActive && (Time.time > powerupInitiated + powerupTimeout))
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);

        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
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
}
