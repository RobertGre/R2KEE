using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{

    public GameObject KeyPlayer;
    public GameObject PickUpTextKey;
    public AudioManager am;

    
    // Start is called before the first frame update
    void Start()
    {
        KeyPlayer.SetActive(false);
        PickUpTextKey.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpTextKey.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {

                Item item = GetComponent<Item>();
                item.AddToInventory();

                this.gameObject.SetActive(false);
                KeyPlayer.SetActive(true);
                PickUpTextKey.SetActive(false);
               
                am.AudioTrigger(AudioManager.SoundFXCat.Key, transform.position, 1f);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        PickUpTextKey?.SetActive(false);
    }


}
