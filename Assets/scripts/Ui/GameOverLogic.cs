using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLogic : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Canvas pickupCanvas;
    [SerializeField] private Canvas healthbarCanvas;
    [SerializeField] private Canvas minimapCanvas;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject enemy;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        pickupCanvas.enabled = true;
        healthbarCanvas.enabled = true;
        minimapCanvas.enabled = true;
        pauseMenu.SetActive(true);
        enemy.SetActive(true);
    }

    public void OnPlayerDeath()
    {
        
    }

    
    public void OnRetryPressed()
    {
        SceneManager.LoadScene("Level01");
        pauseMenu.SetActive(true);
        pickupCanvas.enabled = true;
        healthbarCanvas.enabled = true;
        minimapCanvas.enabled = true;
        enemy.SetActive(true);
    }

    public void OnQuitButton()
    {
        Application.Quit();

        Debug.Log("Player has quit the game...");
    }

}
