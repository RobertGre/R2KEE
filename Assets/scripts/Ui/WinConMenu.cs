using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConMenu : MonoBehaviour
{
   public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void OnCreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }
}
