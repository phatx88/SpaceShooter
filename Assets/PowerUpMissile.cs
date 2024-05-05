using UnityEngine;

public class PowerUpMissile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MissileShooting missileShooting = collision.GetComponent<MissileShooting>();

            if (missileShooting != null)
            {
                missileShooting.AddMissilePowerup();
                //Debug.Log("Missile Power-Up Acquired!");
                
            }
            AudioControler.Instance.PlaySFX("PU_Missile");
            // Destroy the power-up after it has been collected
            Destroy(gameObject);
        }
    }
}
