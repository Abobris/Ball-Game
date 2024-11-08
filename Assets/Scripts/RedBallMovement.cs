using System.Collections;
using UnityEngine;

public class RedBallMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Vector3 originalScale; // Para guardar o tamanho original

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale; // Armazena o tamanho original da bola
        ChangeDirection();

        // Inscreve a bola nos eventos de powerup
        PowerupManager.OnPowerupCollected += ShrinkBall;
        PowerupManager.OnPowerupEnded += RestoreSize;
    }

    void OnDestroy()
    {
        // Desinscreve a bola dos eventos quando ela for destru�da
        PowerupManager.OnPowerupCollected -= ShrinkBall;
        PowerupManager.OnPowerupEnded -= RestoreSize;
    }

    void Update()
    {
        rb.velocity = movement * moveSpeed;
    }

    public void ChangeDirection()
    {
        // Muda a dire��o da bola de forma aleat�ria
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        movement = new Vector2(randomX, randomY).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 reflectDirection = Vector2.Reflect(movement, collision.contacts[0].normal); // Reflete o movimento da bola com base no ponto de colis�o
            movement = reflectDirection.normalized; // Normaliza a nova dire��o
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over! O jogador foi atingido pela bola vermelha.");
            // L�gica para game over ou reiniciar o jogo
        }
    }

    // M�todo para encolher a bola ao coletar o powerup
    void ShrinkBall()
    {
        transform.localScale = originalScale * 0.5f;
    }

    // M�todo para restaurar o tamanho original da bola ap�s 10 segundos
    void RestoreSize()
    {
        transform.localScale = originalScale;
    }
}