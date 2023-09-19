using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_End : MonoBehaviour
{
    public Animator animator;
    public AudioSource deathsound;
    [SerializeField] AudioSource hurtsound;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        hurtsound.Play();
        //Play hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        //Die Animation
        animator.SetBool("IsDead", true);
        //Disable the enemy
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
        deathsound.Play();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreKeeper_End>().AddScore(1);
    }

    void obliterate()
    {
        Destroy(this.gameObject);
    }

}
