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
        // Desinscreve a bola dos eventos quando ela for destruída
        PowerupManager.OnPowerupCollected -= ShrinkBall;
        PowerupManager.OnPowerupEnded -= RestoreSize;
    }

    void Update()
    {
        rb.velocity = movement * moveSpeed;
    }

    public void ChangeDirection()
    {
        // Muda a direção da bola de forma aleatória
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        movement = new Vector2(randomX, randomY).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 reflectDirection = Vector2.Reflect(movement, collision.contacts[0].normal); // Reflete o movimento da bola com base no ponto de colisão
            movement = reflectDirection.normalized; // Normaliza a nova direção
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over! O jogador foi atingido pela bola vermelha.");
            // Lógica para game over ou reiniciar o jogo
        }
    }

    // Método para encolher a bola ao coletar o powerup
    void ShrinkBall()
    {
        transform.localScale = originalScale * 0.5f;
    }

    // Método para restaurar o tamanho original da bola após 10 segundos
    void RestoreSize()
    {
        transform.localScale = originalScale;
    }
}