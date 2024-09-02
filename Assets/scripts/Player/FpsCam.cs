using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCam : MonoBehaviour
{
    public float sensitivity = 2f;
    public Transform playerBody;

    private float verticalRotation = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        // Rotate the player's body horizontally based on mouse X movement
        playerBody.Rotate(Vector3.up * mouseX);

        // Get mouse input for vertical look (optional)
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Update the vertical rotation
        verticalRotation -= mouseY;

        // Clamp the vertical rotation
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        // Apply the rotation
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}


