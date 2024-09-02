using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // movement parameters (can be changed to private after finding the desired values)
    // nicely organised with headers for the inspector
    [Header("Movement")]
    public float walkSpeed;
    public float sprintSpeed;
    private float currentSpeed;
    public float groundDrag;

    private PlayerInput playerInput;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;

    [Header("Orientation")]
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [Header("Audio")]
    public AudioManager am;
    float sinceLastFootstep;
    float timeBetweenFootsteps = 0.7f;
    float timeBetweenruningFootsteps = 0.45f;

    [Header("Canvas")]
    public GameObject mapCanvas;
    private bool isMapActive = false;
    [SerializeField] GameObject pauseManager;
    [SerializeField] GameObject minimapCanvas;
    [SerializeField] GameObject healthCanvas;
    [SerializeField] GameObject pickupCanvas;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
        currentSpeed = walkSpeed;

        playerInput = GetComponent<PlayerInput>();
        mapCanvas.SetActive(false);
    }
    // Handle player input
    private void MyInput()
    {
        //horizontalInput = Input.GetAxisRaw("Horizontal");
        //verticalInput = Input.GetAxisRaw("Vertical");

        // Sprinting logic
        float sprintInput = playerInput.actions["Sprint"].ReadValue<float>();
        if (sprintInput > 0f)
        {
            currentSpeed = sprintSpeed;
            sinceLastFootstep += Time.deltaTime;
            if (sinceLastFootstep > timeBetweenruningFootsteps)
            {
                sinceLastFootstep = 0f;
                am.AudioTrigger(AudioManager.SoundFXCat.FootSteps, transform.position, .2f);
            }
        }
        else
        {
            currentSpeed = walkSpeed;
        }
        //Debug.Log("Current Speed: " + currentSpeed);

        // Jumping logic
        float jumpInput = playerInput.actions["Jump"].ReadValue<float>();
        if (jumpInput > 0f && readyToJump && grounded) // If the jump button is held down
        {
            readyToJump = false;
            Jump();
            am.AudioTrigger(AudioManager.SoundFXCat.Jumping, transform.position, .5f);
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);

        MyInput();
        SpeedControl();

        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        verticalInput = move.z;
        horizontalInput = move.x;
        move.y = 0f;

        // Apply ground drag based on the player's state which slows down the player for more realism
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if (playerInput.actions["Map"].triggered)
        {
            ToggleMap();
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Apply force based on the player's state (grounded or airborne)
        if (grounded)
            rb.AddForce(moveDirection.normalized * walkSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * walkSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    // Control for the player's speed to prevent exceeding the specified limit
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > currentSpeed)
        {
            sinceLastFootstep += Time.deltaTime;
            if(sinceLastFootstep > timeBetweenFootsteps)
            {
                sinceLastFootstep = 0f;
                am.AudioTrigger(AudioManager.SoundFXCat.FootSteps, transform.position, .2f);
            }
            Vector3 limitedVel = flatVel.normalized * currentSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    
    // Apply force to make the player jump
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    // Reset the jump flag after the cooldown period
    private void ResetJump()
    {
        readyToJump = true;
    }

    private void ToggleMap()
    {
        isMapActive = !isMapActive;
        mapCanvas.SetActive(isMapActive);
        if (isMapActive)
        {
            Time.timeScale = 0f;
            minimapCanvas.SetActive(false);
            healthCanvas.SetActive(false);
            pickupCanvas.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            minimapCanvas.SetActive(true);
            healthCanvas.SetActive(true);
            pickupCanvas.SetActive(true);
        }
    }
}