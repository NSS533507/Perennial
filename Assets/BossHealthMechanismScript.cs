using UnityEngine;
using UnityEngine.UI;  // Required to interact with the UI Slider

public class BossHealthMechanismScript : MonoBehaviour
{
    // Boss health variables
    public int maxHealth = 100;  // Max health of the boss
    private int currentHealth;   // Current health of the boss

    // Reference to the health slider (UI element)
    public Slider healthSlider;

    // Damage value when the MC collides with the boss
    public int damageAmount = 10;  // Example damage value, you can adjust this

    // Animator reference (for triggering animations based on health)
    private Animator anim;
    public GameObject gameOverScreen;

    void Start()
    {
        // Initialize the current health to max health at the start of the game
        currentHealth = maxHealth;

        // Initialize the health slider
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;  // Set max value of the slider
            healthSlider.value = currentHealth; // Set current health value
        }

        // Get the Animator component
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Update the health slider if needed (e.g., if you modify health in other ways)
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // Update animation triggers based on current health
        if (currentHealth <= 70 && currentHealth > 30)
        {
            anim.SetTrigger("P2");  // Trigger Phase 2 animation
        }
        else if (currentHealth <= 30 && currentHealth > 0)
        {
            anim.SetTrigger("P3");  // Trigger Phase 3 animation
        }
    }

    // Function to reduce health (called when the boss takes damage)
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0)
        {
            currentHealth = 0;  // Prevent health from going below 0
        }

        // Update the health slider
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // Check if the boss's health is 0 or below (boss defeated)
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Function to handle boss death (called when health reaches 0)
    private void Die()
    {
        // Trigger any death animations if needed
        anim.SetTrigger("Die");

        // Destroy the boss object
        Destroy(gameObject);

        // Trigger win screen via logicScript (adjust to your logic)
        logicScript.instance.WinScreen();
    }

    // Optionally, add healing functionality (e.g., for the boss to recover health)
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;  // Prevent health from going above max
        }

        // Update the health slider
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }

    // Detect collisions with the Main Character (MC)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the Main Character (MC)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the TakeDamage method to reduce boss health
            TakeDamage(damageAmount);

            // Optional: You could add some feedback or effects here, like a sound or particle effect.
        }
        if(collision.gameObject.CompareTag("Fairy") )
        {
            // Optional: You could add some feedback or effects here, like a sound or particle effect.
            GameOver();
        }
    }
    public void GameOver()
    {
        // Show the game over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

}
