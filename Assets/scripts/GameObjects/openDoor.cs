using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject Door1;
    public GameObject KeyItem;
    public AudioManager am;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name ==  "KeyItem")
        {
             Destroy(Door1);
             Destroy(KeyItem);
            //Debug.Log("col");
            am.AudioTrigger(AudioManager.SoundFXCat.Door, transform.position, .7f);
        }
    }
}
