using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
   public void OnStartGameButton ()
    {
        SceneManager.LoadScene(3);
    }

    public void OnSettingsGameButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OnCreditsGameButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnQuitButton()
    {
        Application.Quit();

        Debug.Log("Player has quit the game...");
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("StartScreen");
    }

}
