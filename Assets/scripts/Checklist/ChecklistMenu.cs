using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChecklistMenu : MonoBehaviour
{
    public GameObject ChecklistPanel;
    private bool menuActivated;
    public Toggle antenna, satellite, generator, wires, carBattery;    //call this from other pickup scripts

    void Start()
    {
       ChecklistPanel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (menuActivated)
            {
                Time.timeScale = 1;
                ChecklistPanel.SetActive(false); // Deactivates menu
                menuActivated = false;
            }
            else
            {
                Time.timeScale = 1; // Pauses the game
                ChecklistPanel.SetActive(true); // Activates menu
                menuActivated = true;
            }
        }
    }
}
