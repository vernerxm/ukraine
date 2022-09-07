using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    

    private Rigidbody2D rb;
    private Animator anim;
    public int MaxHealth = 100;
    public int Health;
    private HealhBar HealhBar;
    [SerializeField] private AudioSource DeathSound;


    void Start()
    {
        HealhBar = GameObject.FindGameObjectWithTag("HealhBar").GetComponent<HealhBar>();


        rb = GetComponent<Rigidbody2D>();
        Health = MaxHealth;
        HealhBar.SetMaxHealth(MaxHealth);
        anim = GetComponent<Animator>();
    }

    
    void TakeDamage(int damage)
    {
        Health -= damage;
        HealhBar.SetHealth(Health);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TRAP")){
            
            Destroy(collision.gameObject);
            TakeDamage(100);
            if(Health <= 0)
            {
                Die();
            }
        }
    }
    private void Die()
    {
        DeathSound.Play();
        rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
        
        
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
