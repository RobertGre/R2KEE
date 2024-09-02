using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject FlashLightPlayer;
    public GameObject PickupText;
    public AudioManager am;

    void Start()
    {
        FlashLightPlayer.SetActive(false);
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

                this.gameObject.SetActive(false);

                FlashLightPlayer.SetActive(true);

                PickupText.SetActive(false);
                am.AudioTrigger(AudioManager.SoundFXCat.PickUp, transform.position, .7f);
            }
        }
    }
   private void OnTriggerExit(Collider other)
   {
        PickupText.SetActive(false);
   }
}
