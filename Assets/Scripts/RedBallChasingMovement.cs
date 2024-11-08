using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallChasingMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Transform playerTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        ChangeDirection(); // Direção inicial aleatória
    }

    void Update()
    {
        rb.velocity = movement * moveSpeed;
    }

    public void ChangeDirection()
    {
        // Move numa direção aleatória
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        movement = new Vector2(randomX, randomY).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Ao bater na parede, direciona a bola para a posição do jogador
            Vector2 playerPosition = playerTransform.position;
            movement = (playerPosition - rb.position).normalized;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over! O jogador foi atingido pela bola vermelha.");
            // Lógica de game over ou penalidade
        }
    }
}
