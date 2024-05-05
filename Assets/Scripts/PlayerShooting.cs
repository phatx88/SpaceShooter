#region Normal Shooting
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
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Shoot();
            cooldownTimer = fireDelay;
        }
    }

    void Shoot()
    {
        // Default shooting behavior
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
            return Random.Range(-30f, 30f);
        }
        else
        {
            float maxAngleSpread = 360f;
            return maxAngleSpread / numBullets;
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


//#region Shooting with powerups

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerShooting : MonoBehaviour
//{
//    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
//    public GameObject bulletPrefab;
//    public int powerupCount = 0;
//    public int maxPowerupCount = 16;

//    int bulletLayer;
//    float fireDelay = 0.25f;
//    float cooldownTimer = 0;

//    private MissileShooting missileShooting; //Add Missle Shooting Functionality

//    private void Awake()
//    {
//        bulletLayer = gameObject.layer;
//        missileShooting = GetComponent<MissileShooting>(); // Reference the MissileShooting script
//    }

//    void Update()
//    {
//        cooldownTimer -= Time.deltaTime;  //thay the bang start couroutine 

//        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
//        {
//            Shoot();
//            cooldownTimer = fireDelay;
//        }
//    }

//    void Shoot()
//    {
//        // Always shoot the first bullet directly forward
//        InstantiateBullet(0);

//        if (powerupCount > 0)
//        {
//            float spreadAngle = CalculateSpreadAngle(powerupCount);
//            for (int i = 1; i <= powerupCount; i++)
//            {
//                float angle = spreadAngle * (i - powerupCount / 2.0f);
//                InstantiateBullet(angle);
//            }
//        }

//        AudioControler.Instance.PlaySFX("Laser_01");
//    }

//    void InstantiateBullet(float angle)
//    {
//        Quaternion rotation = Quaternion.Euler(0, 0, angle) * transform.rotation;
//        Vector3 position = transform.position + rotation * bulletOffset;
//        GameObject bullet = Instantiate(bulletPrefab, position, rotation);
//        bullet.layer = bulletLayer;
//    }

//    float CalculateSpreadAngle(int numBullets)
//    {
//        if (numBullets == 1)
//        {
//            // Only one additional bullet, can be in any direction
//            return Random.Range(-30f, 30f);
//        }
//        else
//        {
//            // Calculate spread angle, increasing spread until it reaches full 360 degrees with max power-ups
//            float maxAngleSpread = 360f;
//            return maxAngleSpread / numBullets; // Evenly space each bullet in a full circle
//        }
//    }
//    public void AddPowerup()
//    {
//        if (powerupCount < maxPowerupCount)
//        {
//            powerupCount++;
//            Debug.Log("Power-up added. Total power-ups: " + powerupCount);
//        }
//        else
//        {
//            Debug.Log("Maximum power-ups reached.");
//        }
//    }

//    // Activate the Missile Shooting script and disable this script
//    public void EnableMissileShooting()
//    {
//        missileShooting.enabled = true;
//        enabled = false; // Disable this script
//    }
//}





//#endregion
