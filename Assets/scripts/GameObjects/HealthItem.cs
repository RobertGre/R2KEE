using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthIncrease = 10; // Amount of health to increase
    public HealthBar healthBar; // Reference to the player's health bar
    public AudioManager am;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player object
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Increase the player's health
                playerHealth.Heal(healthIncrease);

                // Update the health bar UI
                healthBar.SetHealth(playerHealth.currentHealth);

                // Destroy the health item object
                Destroy(gameObject);
                am.AudioTrigger(AudioManager.SoundFXCat.AppleCrunch, transform.position, .7f);
            }
        }
    }
}




