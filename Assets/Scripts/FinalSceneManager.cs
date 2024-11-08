using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalSceneManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Atribua isso no Inspector
    public TextMeshProUGUI newHighScoreText; // Atribua isso no Inspector

    void Start()
    {
        // Verificação de nulidade para evitar erros de referência nula
        if (scoreText == null)
        {
            Debug.LogError("Score Text não foi atribuído no Inspector!");
            return;
        }

        if (newHighScoreText == null)
        {
            Debug.LogError("New High Score Text não foi atribuído no Inspector!");
            return;
        }

        // Obtenha a pontuação final do PlayerMovement
        int finalScore = PlayerMovement.score;
        scoreText.text = "Pontuação Final: " + finalScore.ToString();

        // Verifica se o jogador bateu o recorde
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log("Pontuação Final: " + finalScore + ", Pontuação Máxima: " + highScore); // Depuração

        if (finalScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", finalScore);
            PlayerPrefs.Save();
            Debug.Log("Novo recorde atingido!");
            newHighScoreText.text = "New Record!";
        }
        else
        {
            newHighScoreText.text = "";
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainGame");
        PlayerMovement.score = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
