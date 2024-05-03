using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int health = 1;
    public int maxPlayerHealth = 3;

    public float invulnPeriod = 0;
    public float maxPlayerInvulPeriod = 3;

    //set Invulnabiliy Time;
    float invulnTimer = 0;
    int correctLayer;

    SpriteRenderer spriteRend;

    //Add Audio
    AudioManager audioManager;

    //Add-update HealthBar UI
    HealthBar healthBar;

    //Add ScoreManager
    ScoreManager scoreManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    void Start()
    {
        correctLayer = gameObject.layer;
        

        //Set health Plyer
        if(gameObject.tag == "Player")
        {
            health = maxPlayerHealth;
            healthBar.SetMaxHeath(health); //Set Maxhealth to HealthBar

            invulnPeriod = maxPlayerInvulPeriod; //Add Invuln time to Player
        }

        //Get the renderer, Only work on Parent not the chidren
        spriteRend = GetComponent<SpriteRenderer>();

        if(spriteRend == null)
        {
            //Get the renderer of the childre
            spriteRend = GetComponentInChildren<SpriteRenderer>();
            if(spriteRend == null)
            {
            Debug.Log("Object '"+gameObject.name+"' has no sprite rendered.");
            }
        }
    }

    //On Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");

        #region Trigger Invulnebility
        TriggerInvulnerability(true, maxPlayerInvulPeriod);
        #endregion

    }

    void Update()
    {
        //Update Invulnerability and reset
        HandleInvulnerability();
            
       //Destroy gameobject if its health go to 0
        if (health <= 0)
        {
            //Play Sound When Targets Health less than equal to zero
            if (gameObject.tag == "Player" || gameObject.tag == "Enemy")
            {
                audioManager.PlaySFX(audioManager.death);
            }

            //Add case to score 
            switch (gameObject.tag)
            {
                case "Enemy":
                    scoreManager.scoreIncreasement(10);
                    break;
                //case "Strong Enemy":
                //    scoreManager.scoreIncreasement(20);
                //    break;
                //case "Asteroid":
                //    scoreManager.scoreIncreasement(5);
                //    break;
                default:
                    // Optional: Handle unexpected tags or do nothing
                    break;
            }
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    #region Trigger & Handle Invulnerability
    public void TriggerInvulnerability(bool takeDamaged, float maxTimer)
    {
        //Add so that Player become temporary invulnerable upon collision 
        if (invulnTimer <= 0)
        {
            if (takeDamaged)
            {
            health--; //Take damage if with out Invulnaripity period

                if (gameObject.tag == "Player")
                {
                healthBar.SetHealth(health); // Show Reduced HealthBar
                }
            }

            invulnTimer = maxTimer; //call timer for invulnable 

            gameObject.layer = 10; //change to invulnable 
        }
    }
    public void HandleInvulnerability()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer; // Restore original layer
                spriteRend.enabled = true; // Make sure sprite is visible when not invulnerable
            }
            else
            {
                spriteRend.enabled = !spriteRend.enabled; // Blink effect for invulnerability
            }
        }
    }
    #endregion
}
