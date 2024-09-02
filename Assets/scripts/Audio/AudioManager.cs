using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum SoundFXCat { FootSteps, Key, Door, PickUp, Damage, FlashLight, Chase, CarHit, AppleCrunch, Jumping, Reload, BoothNo, BoothYes }
    public GameObject audioObject;
    public AudioClip[] footSteps;
    public AudioClip[] flashlight;
    public AudioClip[] key;
    public AudioClip[] door;
    public AudioClip[] pickUp;
    public AudioClip[] damage;
    public AudioClip[] chase;
    public AudioClip[] carHit;
    public AudioClip[] appleCrunch;
    public AudioClip[] jumping;
    public AudioClip[] reload;
    public AudioClip[] boothNo;
    public AudioClip[] boothYes;


    public void AudioTrigger(SoundFXCat AudioType, Vector3 audioPosition, float volume)
    {
        GameObject newAudio = GameObject.Instantiate(audioObject, audioPosition, Quaternion.identity);
        ControlAudio ca = newAudio.GetComponent<ControlAudio>();
        switch (AudioType)
        {
            case (SoundFXCat.FootSteps):
                ca.myClip = footSteps[Random.Range(0, footSteps.Length)];
                break;
            case (SoundFXCat.Key):
                ca.myClip = key[Random.Range(0, key.Length)];
                break;
            case (SoundFXCat.Door):
                ca.myClip = door[Random.Range(0, door.Length)];
                break;
            case (SoundFXCat.PickUp):
                ca.myClip = pickUp[Random.Range(0, pickUp.Length)];
                break;
            case (SoundFXCat.Damage):
                ca.myClip = damage[Random.Range(0, damage.Length)];
                break;
            case (SoundFXCat.FlashLight):
                ca.myClip = flashlight[Random.Range(0, flashlight.Length)];
                break;
            case (SoundFXCat.Chase):
                ca.myClip = chase[Random.Range(0, chase.Length)];
                break;
            case (SoundFXCat.CarHit):
                ca.myClip = carHit[Random.Range(0, carHit.Length)];
                break;
            case (SoundFXCat.AppleCrunch):
                ca.myClip = appleCrunch[Random.Range(0, appleCrunch.Length)];
                break;
            case (SoundFXCat.Jumping):
                ca.myClip = jumping[Random.Range(0, jumping.Length)];
                break;
            case (SoundFXCat.Reload):
                ca.myClip = reload[Random.Range(0, reload.Length)];
                break;
            case (SoundFXCat.BoothNo):
                ca.myClip = boothNo[Random.Range(0, boothNo.Length)];
                break;
            case (SoundFXCat.BoothYes):
                ca.myClip = boothYes[Random.Range(0, boothYes.Length)];
                break;
        }

        ca.volume = volume;
        ca.StartAudio();
    }

}
