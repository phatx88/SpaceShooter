using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public int health = 1;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerShooting playerShooting = collision.gameObject.GetComponent<PlayerShooting>();
            if (playerShooting != null)
            {
                playerShooting.AddPowerup();
                audioManager.PlaySFX(audioManager.powerupCollect); // Assuming you have this SFX
            }
            Destroy(gameObject);
        }
    }
}
