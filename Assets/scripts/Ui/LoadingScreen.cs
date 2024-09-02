using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;



  public void LoadLevel (int sceneIndex)
   {
        StartCoroutine(LoadAsynchronously(sceneIndex));
       
   }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        // LoadSceneAsync loads the game while everything in the background is running
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);



        while (!operation.isDone) // while loop untill the process is done
        {
            // this makes sure that it goes to 1 and not 0.9 as unity only goes from 0 to 0.9, so using this line can make sure it goes from 0 to 1
            float progress = Mathf.Clamp01(operation.progress / .9f); 
            
           slider.value = progress; // this increases the loading slider based on the progress of the level loading

            yield return new WaitForSeconds(0f); // wait a frame before we repeat loop, the new WaitForSeconds adds a delay between waiting so the game doesnt load very quickly
        }
    } 

}
