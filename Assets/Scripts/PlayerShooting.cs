#region Normal Shooting

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerShooting : MonoBehaviour
//{
//    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
//    public GameObject bulletPrefab;

//    //Add this to avoid Invulnerable Bullet Layer
//    int bulletLayer;

//    public float fireDelay = 0.25f;
//    float cooldownTimer = 0;

//    //Add Audio
//    AudioManager audioManager;
//    private void Awake()
//    {
//        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
//    }

//    void Start()
//    {
//        bulletLayer = gameObject.layer;
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        cooldownTimer -= Time.deltaTime;

//        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
//        {
//            //Debug.Log("Pew");
//            cooldownTimer = fireDelay;

//            //move Instantiate point to ontop of the ship
//            Vector3 offset = transform.rotation * bulletOffset;

//            //Set bullet to same layer with GameObject that it's applying to
//            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
//            audioManager.PlaySFX(audioManager.laserFire_01); //add fire sound
//            bulletGO.layer = bulletLayer;
//        }
//    }
//}

#endregion


#region Shooting with powerups

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;
    public int powerupCount = 0;
    public int maxPowerupCount = 16;

    int bulletLayer;
    float fireDelay = 0.25f;
    float cooldownTimer = 0;


    private void Awake()
    {
        bulletLayer = gameObject.layer;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;  //thay the bang start couroutine 

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Shoot();
            cooldownTimer = fireDelay;
        }
    }

    void Shoot()
    {
        // Always shoot the first bullet directly forward
        InstantiateBullet(0);

        if (powerupCount > 0)
        {
            float spreadAngle = CalculateSpreadAngle(powerupCount);
            for (int i = 1; i <= powerupCount; i++)
            {
                float angle = spreadAngle * (i - powerupCount / 2.0f);
                InstantiateBullet(angle);
            }
        }

        AudioControler.Instance.PlaySFX("Laser_01");
    }

    void InstantiateBullet(float angle)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, angle) * transform.rotation;
        Vector3 position = transform.position + rotation * bulletOffset;
        GameObject bullet = Instantiate(bulletPrefab, position, rotation);
        bullet.layer = bulletLayer;
    }

    float CalculateSpreadAngle(int numBullets)
    {
        if (numBullets == 1)
        {
            // Only one additional bullet, can be in any direction
            return Random.Range(-30f, 30f);
        }
        else
        {
            // Calculate spread angle, increasing spread until it reaches full 360 degrees with max power-ups
            float maxAngleSpread = 360f;
            return maxAngleSpread / numBullets; // Evenly space each bullet in a full circle
        }
    }
    public void AddPowerup()
    {
        if (powerupCount < maxPowerupCount)
        {
            powerupCount++;
            Debug.Log("Power-up added. Total power-ups: " + powerupCount);
        }
        else
        {
            Debug.Log("Maximum power-ups reached.");
        }
    }
}





#endregion
