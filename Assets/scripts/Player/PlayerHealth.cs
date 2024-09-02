using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] GameObject pauseMenu;
    public FpsCam fc;


    

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
    }

    // Method to increase the player's health
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure current health doesn't exceed max health
        healthBar.SetHealth(currentHealth);
    }



    // Method to reduce player's health
    public void TakeDamage(int damage)
     { 
        currentHealth -= damage;

        // Updates health bar
        healthBar.SetHealth(currentHealth);

        // Check if player's health reaches zero
        if (currentHealth <= 0)
        {
            Die();
        }
     }

    // Method to handle player's death
    void Die()
    {
        gameOverCanvas.enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 0.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        fc.sensitivity = 0;
        Debug.Log("Player died!");
    }

    void Update()
    {
        CheatModes();
    }

    void CheatModes()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            // Call IncreaseHealth with a cheat value
            Heal(20);
        }
    }

}

