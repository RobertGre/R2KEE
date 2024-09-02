using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputAction pauseButton;
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas pickupCanvas;
    [SerializeField] private Canvas healthbarCanvas;
    [SerializeField] private Canvas minimapCanvas;
    [SerializeField] private Canvas timerCanvas;
    public FpsCam fc;

    private bool paused = false;
    private float initialSensitivity;

    private void OnEnable()
    {
        pauseButton.Enable();
    }

    private void OnDisable()
    {
        pauseButton.Disable();
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        pauseCanvas.enabled = false;
        pauseButton.performed += _ => Pause();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        initialSensitivity = fc.sensitivity;
    }

    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            pauseCanvas.enabled = true;
            pickupCanvas.enabled = false;
            healthbarCanvas.enabled = false;
            minimapCanvas.enabled = false;
            timerCanvas.enabled = false;
            fc.sensitivity = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            Time.timeScale = 1;
            pauseCanvas.enabled = false;
            pickupCanvas.enabled = true;
            healthbarCanvas.enabled = true;
            minimapCanvas.enabled = true;
            timerCanvas.enabled = true;
            fc.sensitivity = initialSensitivity;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
