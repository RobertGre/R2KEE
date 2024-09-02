using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BatteryPickup : MonoBehaviour
{
    public GameObject PickupText;
    public GameObject flashlight;
    public AudioManager am;

    private bool inArea = false;

    void Start()
    {
        PickupText.SetActive(false);        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inArea = true;
            PickupText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inArea = false;
            PickupText.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inArea) // Check if the F key is pressed while in the pickup area
        {

            Item item = GetComponent<Item>();
            item.AddToInventory();

            flashlight.GetComponent<FlashLight>().batteries += 1; // Increase battery count in the FlashLight script
            PickupText.SetActive(false); // Hide pickup text
            am.AudioTrigger(AudioManager.SoundFXCat.PickUp, transform.position, .7f);
            Destroy(gameObject); // Destroy the battery pickup object
        }
    }
}
