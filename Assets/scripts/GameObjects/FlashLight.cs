using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // accessing text mesh pro

public class FlashLight : MonoBehaviour
{
    public Light flashLight;
    public TMP_Text text;
    public TMP_Text batteryText;
    public float lightHealth = 100; 
    public float batteries = 0;
    private bool on = false; 
    private bool off = true;
    public AudioManager am;

    void Start()
    {
        flashLight = GetComponent<Light>(); // grabs the light component
        flashLight.enabled = false;
    }

    void Update()
    {
        text.text = "Flashlight Health: " + lightHealth.ToString("0") + "%"; //text for health
        batteryText.text = "Batteries: " + batteries.ToString(); // text for battery

        if (Input.GetKeyDown(KeyCode.R) && off) //if button down turns on flashlight
        {
            flashLight.enabled = true;
            on = true;
            off = false;
            am.AudioTrigger(AudioManager.SoundFXCat.FlashLight, transform.position, .7f);
        }
        else if (Input.GetKeyDown(KeyCode.R) && on) //turns light off if it's on and R is pressed
        {
            flashLight.enabled = false;
            on = false;
            off = true;
            am.AudioTrigger(AudioManager.SoundFXCat.FlashLight, transform.position, .7f);
        }

        if (on) // if light is on health gets decreased every second in real time
        {
            lightHealth -= 1 * Time.deltaTime;
        }

        if (lightHealth <= 0) // if health < 0 disable light & set health to 0
        {
            flashLight.enabled = false;
            lightHealth = 0;
        }

        if (lightHealth >= 100) // if health is greater than 100 always set it 100
        {
            lightHealth = 100;
        }

        if (Input.GetKeyDown(KeyCode.E) && batteries >= 1 && !on) 
        {
            am.AudioTrigger(AudioManager.SoundFXCat.Reload, transform.position, .7f);
            batteries -= 1;
            lightHealth += 50;
            if (lightHealth > 100) // Check if lightHealth exceeds 100
            {
                lightHealth = 100;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && batteries == 0) // if reload with 0 battery does nothing
        {
            return;
        }

        if (batteries <= 0) // if battery is below 0 set it back to 0
        {
            batteries = 0;
        }
    }
}




