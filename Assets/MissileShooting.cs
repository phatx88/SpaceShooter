using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissileShooting : MonoBehaviour
{
    public GameObject missilePrefab; // Prefab for the missile
    public Vector3 missileOffset = new Vector3(0, 0.5f, 0);
    public int barrageCount = 36; // Total number of missiles in the barrage
    public float fireDelay = 0.1f; // Delay between each missile launch
    private float cooldownTimer = 0;
    private bool isShootingBarrage = false;

    private int missilePowerupCount = 0; // How many missile power-ups the player has collected

    public float missileCooldown = 5f; // Minimum time between missile barrages

    //Configure UI
    private TextMeshProUGUI missileText;


    private void Start()
    {
        // Initialize the Missile Text reference
        missileText = GameObject.FindGameObjectWithTag("BulletUI").GetComponent<TextMeshProUGUI>();
        
    }
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButtonDown("Fire2") && missilePowerupCount > 0 && cooldownTimer <= 0)
        {
            ShootMissileBarrage();
            missilePowerupCount--;
        }
        UpdateMissileDisplay();
    }

    public void AddMissilePowerup()
    {
        missilePowerupCount++;
        Debug.Log("Missile Power-Up collected! Total: " + missilePowerupCount);
    }

    public void ShootMissileBarrage()
    {
        

        if (!isShootingBarrage && cooldownTimer <= 0)
        {
            
            StartCoroutine(ShootBarrage());

            cooldownTimer = barrageCount * fireDelay + missileCooldown; // Ensure the cooldown matches the barrage duration + cooldown
        }
    }

    private IEnumerator ShootBarrage()
    {
        isShootingBarrage = true;

        // Add SFX to Open Barrage
        AudioControler.Instance.PlaySFX("Missile_Launch");

        for (int i = 0; i < barrageCount; i++)
        {
            ShootMissile();
            yield return new WaitForSeconds(fireDelay);
        }

        isShootingBarrage = false;
    }

    void ShootMissile()
    {
        // Add SFX to Missile Sound
        AudioControler.Instance.PlaySFX("Missile");

        // Instantiate the missile at the offset position
        Quaternion rotation = transform.rotation;
        Vector3 position = transform.position + rotation * missileOffset;
        GameObject missile = Instantiate(missilePrefab, position, rotation);

        // Find a random enemy and assign it to the missile
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            GameObject target = enemies[Random.Range(0, enemies.Length)];
            MissileTargeting missileTarget = missile.GetComponent<MissileTargeting>();

            if (missileTarget != null)
            {
                missileTarget.SetTarget(target.transform);
            }
        }
    }

    //Configure GUI
    private void UpdateMissileDisplay()
    {
        // Update the score text if it's not null
        if (missileText != null)
            missileText.text = $"Missiles: {missilePowerupCount}";
    }
}
