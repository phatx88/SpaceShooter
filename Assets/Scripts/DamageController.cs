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
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
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

        //Add so that Player become temporary invulnerable upon collision 
        if(invulnTimer <= 0)
        {
            health--; //Take damage if with out Invulnaripity period

            if (gameObject.tag == "Player")
            {
                healthBar.SetHealth(health); // Show Reduced HealthBar
              
            }

            invulnTimer = invulnPeriod; //Reset Invulnaripity period

            gameObject.layer = 10; //change back to normal layer
        }

    }

    void Update()
    {
        if(invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                //Add Invulnerable by shifting layer to Invulnerable aboid all collision
                gameObject.layer = correctLayer;

                //Adding Visual Effect of Invulnerability
                //Turn on when Invul time is up
                if (spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                //Turn on/off spriteRender for Visual Effect of Invulnerability
                //Turn on when Invul time is up
                if (spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled; //Turn On/Off sprite renderer on everyframe (Update)
                }
            }
                   
        }
            
        

       //Destroy gameobject if its health go to 0

        if (health <= 0)
        {
            if (gameObject.tag == "Player" || gameObject.tag == "Enemy")
            {
                audioManager.PlaySFX(audioManager.death);
            }
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
