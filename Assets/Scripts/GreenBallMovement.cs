using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector2 movement;
    private Rigidbody2D rb;

    public GameObject redBallPrefab; // Referência ao prefab da bola vermelha
    public GameObject redBallChasingPrefab; // Referência ao prefab da bola vermelha que persegue

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    void Update()
    {
        rb.velocity = movement * moveSpeed;
    }

    public void ChangeDirection()
    {
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
            PlayerMovement playerController = collision.gameObject.GetComponent<PlayerMovement>();
            playerController.AddScore();

            // Teletransporta a bola verde para um local aleatório
            Vector2 randomPosition = new Vector2(Random.Range(-7f, 7f), Random.Range(-4f, 4f));
            transform.position = randomPosition;
            ChangeDirection();

            // Determina aleatoriamente se spawnar uma bola vermelha normal ou que persegue
            GameObject ballToSpawn = Random.Range(0f, 1f) < 0.5f ? redBallPrefab : redBallChasingPrefab;
            Instantiate(ballToSpawn, randomPosition, Quaternion.identity);
        }
    }
}