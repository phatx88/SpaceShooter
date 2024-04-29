using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int health = 1;

    public float invulnPeriod = 0;
    //set Invulnabiliy Time;
    float invulnTimer = 0;
    int correctLayer;

    SpriteRenderer spriteRend;

    void Start()
    {
        correctLayer = gameObject.layer;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");

        if(invulnTimer <= 0)
        {
        health--;
            invulnTimer = invulnPeriod;

            gameObject.layer = 10;
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
            
        

       

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
