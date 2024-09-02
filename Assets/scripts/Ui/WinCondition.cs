using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject winCanvas;

    // True or false for whether the player has picked up the items

    [Header("Win condition Objects")]
    public GameObject satelliteObject;
    public GameObject carBatteryObject;
    public GameObject antennaObject;
    public GameObject generatorObject;
    public GameObject wiresObject;

    [Header("Object bools")]
    [SerializeField] private bool satellitePickedUp;
    [SerializeField] private bool carBatteryPickedUp;
    [SerializeField] private bool antennaPickedUp;
    [SerializeField] private bool generatorPickedUp;
    [SerializeField] private bool wiresPickedUp;
    private float initialSensitivity;
    public AudioManager am;

    private void Start()
    {
        winCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered");
            // Check if the player has all items in the inventory
            if (PlayerHasAllItems())
            {
                // Load the win canvas
                winCanvas.SetActive(true);
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    private bool PlayerHasAllItems()
    {
        Debug.Log("Checking if player has all required items.");

        // Check if the player has picked up all required items
        if (!satellitePickedUp || !carBatteryPickedUp || !antennaPickedUp || !generatorPickedUp || !wiresPickedUp)
        {
            am.AudioTrigger(AudioManager.SoundFXCat.BoothNo, transform.position, .7f);
            Debug.Log("Player does not have all required items.");
            return false;
        }
        am.AudioTrigger(AudioManager.SoundFXCat.BoothYes, transform.position, .7f);
        Debug.Log("Player has all required items.");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        return true;
    }


    public void ItemPickedUp(GameObject itemObject)
    {
        // Check if the itemObject is the same as the GameObject corresponding to the picked up item
        if (itemObject == satelliteObject)
        {
            satellitePickedUp = true;
        }
        else if (itemObject == carBatteryObject)
        {
            carBatteryPickedUp = true;
        }
        else if (itemObject == antennaObject)
        {
            antennaPickedUp = true;
        }
        else if (itemObject == generatorObject)
        {
            generatorPickedUp = true;
        }
        else if (itemObject == wiresObject)
        {
            wiresPickedUp = true;
        }
    }
}