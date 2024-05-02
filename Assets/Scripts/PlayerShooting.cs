using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;

    //Add this to avoid Invulnerable Bullet Layer
    int bulletLayer;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    //Add Audio
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        bulletLayer = gameObject.layer;
    }
    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            //Debug.Log("Pew");
            cooldownTimer = fireDelay;

            //move Instantiate point to ontop of the ship
            Vector3 offset = transform.rotation * bulletOffset;

            //Set bullet to same layer with GameObject that it's applying to
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            audioManager.PlaySFX(audioManager.laserFire_01); //add fire sound
            bulletGO.layer = bulletLayer;
        }
    }
}
