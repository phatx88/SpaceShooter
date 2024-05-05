using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private ExplodeAnimation explodeAnimation;
    [SerializeField] private GameObject graphicGO;
    public int health = 1;
    public int maxPlayerHealth = 3;

    public float invulnPeriod = 0;
    public float maxPlayerInvulPeriod = 3;

    //set Invulnabiliy Time;
    float invulnTimer = 0;
    int correctLayer;

    private bool isRunAnimation = false;


    SpriteRenderer spriteRend;


    //Add-update HealthBar UI
    HealthBar healthBar;

    //Add ScoreManager
    ScoreManager scoreManager;
    private void Awake()
    {
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
        if (graphicGO != null)
        {
            spriteRend = graphicGO.GetComponent<SpriteRenderer>();
            //Get the renderer 
            if(spriteRend == null)
            {
            Debug.Log("Object '"+gameObject.name+"' has no sprite rendered.");
            }
        }
        else
        {
            Debug.LogWarning("Graphic GameObject reference is not assigned for " + gameObject.name);
        }
    }

    //On Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger!");

        #region Trigger Invulnebility
        if(collision.gameObject.layer == 7)
        {
            TriggerInvulnerability(false, maxPlayerInvulPeriod);
        }
        else
        TriggerInvulnerability(true, maxPlayerInvulPeriod);
        #endregion

    }

    void Update()
    {
        //Update Invulnerability and reset
        HandleInvulnerability();
            
        
    }

    public IEnumerator Die()
    {
        PlaySound(); //Get Sound

        AddScore(); //Get Score


        if (graphicGO != null)
        {
            graphicGO.SetActive(false);

            if (isRunAnimation == false)
            {
                explodeAnimation.RunAnimation();
                isRunAnimation = true;
            }
            yield return new WaitForSeconds(1f);
        }
        

        Destroy(gameObject);
    }



    #region Trigger & Handle Invulnerability
    public void TriggerInvulnerability(bool takeDamaged, float maxPlayerInvulPeriod)
    {
        //Add so that Player become temporary invulnerable upon collision 
        if (invulnTimer <= 0)
        {
            if (takeDamaged)
            {

                health--; //Take damage if with out Invulnaripity period
                
                if (health <= 0)
                {                 
                    
                    StartCoroutine(Die());
                }

                if (gameObject.tag == "Player")
                {
                healthBar.SetHealth(health); // Show Reduced HealthBar
                }

            }

            invulnTimer = maxPlayerInvulPeriod; //assign timer for invulnable 

            gameObject.layer = 10; //change to invulnable 
        }
    }
    public void HandleInvulnerability()
    {
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0 && spriteRend != null)
            {
                gameObject.layer = correctLayer; // Restore original layer
                spriteRend.enabled = true; // Make sure sprite is visible when not invulnerable
            }
            else if (spriteRend != null)
            {
                spriteRend.enabled = !spriteRend.enabled; // Blink effect for invulnerability
            }
        }
    }
    #endregion
    void PlaySound()
    {
        //Play Sound When Targets Health less than equal to zero
        if (gameObject.tag == "Player" || gameObject.tag == "Enemy" || gameObject.tag == "Meteor")
        {
            AudioControler.Instance.PlaySFX("Death");
        }
        if (gameObject.tag == "SwarmEnemy")
        {
            AudioControler.Instance.PlaySFX("SwarmDeath");
        }
        if (gameObject.tag == "SwarmSpawner")
        {
            AudioControler.Instance.PlaySFX("DeathBig");
        }
    }

    void AddScore()
    {
        //Add case to score 
        switch (gameObject.tag)
        {
            case "Enemy":
                scoreManager.scoreIncreasement(10);
                break;
            case "SwarmEnemy":
                scoreManager.scoreIncreasement(1);
                break;
            case "Meteor":
                scoreManager.scoreIncreasement(5);
                break;
            default:
                // Optional: Handle unexpected tags or do nothing
                break;
        }
    }
}
