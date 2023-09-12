using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public Slider healthBar;
    public int currentHealth;
    public int maxHealth;

    private Animator player_Animator;

    public Transform attackPoint_Transform;
    public float attackPoint_Range = 2f;

    public static bool youLose = false;
    public TextMeshProUGUI loseText;

    // Start is called before the first frame update
    void Start()
    {
        GameState.Get().Start();
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        player_Animator = GetComponent<Animator>();

        // Get your animator component
        // Set canCastMagic to true
    }

    private void Update()
    {
        healthBar.value = currentHealth;
    }

        public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            YouLose();
        }
        // Use this fuction to send damage to your player from your BadGuy.
        // Also can be where you have your "Die" information for your player if they drop below 0 health
        // If so present your Game Over Screen.
    }

    public void YouLose()
    {
        loseText.text = "You're dead! Press ESC and click 'Menu' to try again.";
        Time.timeScale = 0f;
    }

}
