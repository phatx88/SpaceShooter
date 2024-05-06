using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLaserBeam : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerShooting playerShooting = collision.GetComponent<PlayerShooting>();

            if (playerShooting != null)
            {
                playerShooting.EnableLaserShooting();
                Debug.Log("Laser Beam Power-Up Acquired!");
                AudioControler.Instance.PlaySFX("PU_Missile");
            }

            // Destroy the power-up after it has been collected
            Destroy(gameObject);
        }
    }
}
