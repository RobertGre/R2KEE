using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatellitePickUp : MonoBehaviour
{
    public GameObject PickupText;
    public AudioManager am;
    public WinCondition wc;

    [SerializeField] ChecklistMenu checklist;

    void Start()
    {
        PickupText.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickupText.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {

                Item item = GetComponent<Item>();
                item.AddToInventory();

                checklist.satellite.isOn = true; //checklist

                this.gameObject.SetActive(false);

                PickupText.SetActive(false);
                if (wc != null)
                {
                    wc.ItemPickedUp(gameObject); // Pass the GameObject of the picked up item
                }

                am.AudioTrigger(AudioManager.SoundFXCat.PickUp, transform.position, .7f);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        PickupText?.SetActive(false);
    }
}
