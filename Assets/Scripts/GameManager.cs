using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public enum GameState
    {
        Menu,
        Playing
    }

    [SerializeField] public GameState gameState;

    public UnitHealth _playerHealth = new UnitHealth(100,100);

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
        gameManager = this;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void LoadWarehouse()
    {
        SceneManager.LoadScene("Warehouse");
    }

    public void LoadWarehouse1()
    {
        SceneManager.LoadScene("Warehouse1");
    }

    public void LoadWarehouse2()
    {
        SceneManager.LoadScene("Warehouse2");
    }
}
