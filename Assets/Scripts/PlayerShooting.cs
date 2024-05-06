#region Normal Shooting
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

//    private void Awake()
//    {
//        bulletLayer = gameObject.layer;
//    }

//    void Update()
//    {
//        cooldownTimer -= Time.deltaTime;

//        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
//        {
//            Shoot();
//            cooldownTimer = fireDelay;
//        }
//    }

//    void Shoot()
//    {
//        // Default shooting behavior
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
//            return Random.Range(-30f, 30f);
//        }
//        else
//        {
//            float maxAngleSpread = 360f;
//            return maxAngleSpread / numBullets;
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
//}


#endregion

#region Default Shooting with Laser functionality
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

    private LaserShooting laserShooting;

    private void Awake()
    {
        bulletLayer = gameObject.layer;
        laserShooting = GetComponent<LaserShooting>();

        // Ensure LaserShooting is initially disabled
        laserShooting.enabled = false;
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

    public void EnableLaserShooting()
    {
        laserShooting.enabled = true;
        enabled = false; // Disable default shooting
    }
}
#endregion


