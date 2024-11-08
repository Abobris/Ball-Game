using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Notifica o PowerupManager que o powerup foi coletado
            FindObjectOfType<PowerupManager>().PowerupCollected();

            // Destrói o powerup
            Destroy(gameObject);
        }
    }
}
