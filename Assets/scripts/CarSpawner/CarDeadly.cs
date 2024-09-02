using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeadly : MonoBehaviour
{
    public AudioManager am;

   void OnTriggerEnter(Collider other )
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.currentHealth = 0);
                am.AudioTrigger(AudioManager.SoundFXCat.CarHit, transform.position, .6f);
                Debug.Log("Car hit");
            }
        }
    }
}
