using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public GameObject keybindsPanel;
    public GameObject videoPanel;
    public GameObject soundPanel;

    void Start()
    {
        keybindsPanel.SetActive(false);
        videoPanel.SetActive(true);
        soundPanel.SetActive(false);
    }

    public void OnKeybindsButtonClick()
    {
        keybindsPanel.SetActive(true);
        videoPanel.SetActive(false);
        soundPanel.SetActive(false);
    }

    public void OnVideoButtonClick()
    {
        keybindsPanel.SetActive(false);
        videoPanel.SetActive(true);
        soundPanel.SetActive(false);
    }

    public void OnSoundButtonClick()
    {
        keybindsPanel.SetActive(false);
        videoPanel.SetActive(false);
        soundPanel.SetActive(true);
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("StartScreen");
    }
}

