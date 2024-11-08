using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    // Referência ao Animator
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        UpdateScoreText();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Atualizar o parâmetro isMoving no Animator
        animator.SetBool("isMoving", movement != Vector2.zero);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedBall"))
        {
            Debug.Log("Você foi atingido pela bola vermelha. Game Over!");
            ResetScore();

            // Ativar animação de morte
            animator.SetBool("isDead", true);
        }
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
