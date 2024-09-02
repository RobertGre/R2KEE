using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using TMPro.Examples;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI timeRemainingText;
    public float remainingTime;

    bool timerRunning = false;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] GameObject pauseMenu;
    public FpsCam fc;
    private float initialSensitivity;


    void Start()
    {
         initialSensitivity = fc.sensitivity;
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;


            int minutes = Mathf.Max(0, Mathf.FloorToInt(remainingTime / 60));
            int seconds = Mathf.Max(0, Mathf.FloorToInt(remainingTime % 60));
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            fc.sensitivity = initialSensitivity;

        }
        else if (remainingTime <0)
        {
            remainingTime = 0;
            timerText.color = Color.red;

            gameOverCanvas.enabled = true;
            pauseMenu.SetActive(false);
            Time.timeScale = 0.0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            fc.sensitivity = 0;

            timerRunning = false;
            timerText.text = "";
            timeRemainingText.text = "";
            CancelInvoke("UpdateTimer");
        }
    }

    /* private void OnTriggerStay(Collider other)
     {
         if (other.gameObject.tag == "Player" && !timerRunning)
         {
             timerRunning = true;
             InvokeRepeating("UpdateTimer", 1f, 1f);

             if (remainingTime > 0)
             {
                 remainingTime -= Time.deltaTime;
             }
             else if (remainingTime < 0)
             {
                 remainingTime = 0;

                 timerText.color = Color.red;
             }
             timeRemainingText.text = "Time Remaining: ";
             int minutes = Mathf.FloorToInt(remainingTime / 60);
             int seconds = Mathf.FloorToInt(remainingTime % 60);
             timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
         }

     }

     private void OnTriggerExit(Collider other)
     {
         if (other.CompareTag("Player"))
         {
             timerRunning = false;
             timerText.text = "";
             timeRemainingText.text = "";
             CancelInvoke("UpdateTimer");
         }
     }
     void UpdateTimer()
     {
         if (remainingTime > 0) 
         {
             remainingTime -= 1; 

             int minutes = Mathf.Max(0, Mathf.FloorToInt(remainingTime / 60)); 
             int seconds = Mathf.Max(0, Mathf.FloorToInt(remainingTime % 60));
             timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
             Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
             fc.sensitivity = initialSensitivity;
         }
         else
         {
             remainingTime = 0;
             timerText.color = Color.red;

             gameOverCanvas.enabled = true;
             pauseMenu.SetActive(false);
             Time.timeScale = 0.0f;
             Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
             fc.sensitivity = 0;

             timerRunning = false; 
             timerText.text = ""; 
             timeRemainingText.text = "";
             CancelInvoke("UpdateTimer"); 
         }
     }   */
}
        
    

