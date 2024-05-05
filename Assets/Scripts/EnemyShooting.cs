using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    //Add this to avoid Invulnerable Bullet Layer
    int bulletLayer;
    public float fireDelay = 1f;
    float cooldownTimer = 0;

    Transform player;


    private void Awake()
    {

    }
    void Start()
    {
        bulletLayer = gameObject.layer;
    }
    // Update is called once per frame
    void Update()
    {
        //Find the Player Distance so that Enemy will shoot player within Camera view
        if (player == null)
        {
            //Find the player's ship!
            GameObject go = GameObject.FindGameObjectWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        cooldownTimer -= Time.deltaTime;

        //Add condition that Enemy will fire at player when cooldown timer is set to zero, and enemy and player distance are equal to Camera area (Camera size is 5)
        if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 5)
        {
            //Debug.Log("Enemy Pew");
            cooldownTimer = fireDelay;

            //move Instantiate point to ontop of the ship
            Vector3 offset = transform.rotation * bulletOffset;

            //Set bullet to same layer with GameObject that it's applying to
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            AudioControler.Instance.PlaySFX("Laser_02"); //Add fire sound
            bulletGO.layer = bulletLayer;
        }
    }
}
