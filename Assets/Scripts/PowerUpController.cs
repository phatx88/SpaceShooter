using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public int health = 1;

    
    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerShooting playerShooting = collision.gameObject.GetComponent<PlayerShooting>();
            if (playerShooting != null)
            {
                playerShooting.AddPowerup();
                AudioControler.Instance.PlaySFX("PU_Collect");
            }
            Destroy(gameObject);
        }
    }
}
