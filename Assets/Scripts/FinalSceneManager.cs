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
        // Verifica��o de nulidade para evitar erros de refer�ncia nula
        if (scoreText == null)
        {
            Debug.LogError("Score Text n�o foi atribu�do no Inspector!");
            return;
        }

        if (newHighScoreText == null)
        {
            Debug.LogError("New High Score Text n�o foi atribu�do no Inspector!");
            return;
        }

        // Obtenha a pontua��o final do PlayerMovement
        int finalScore = PlayerMovement.score;
        scoreText.text = "Pontua��o Final: " + finalScore.ToString();

        // Verifica se o jogador bateu o recorde
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log("Pontua��o Final: " + finalScore + ", Pontua��o M�xima: " + highScore); // Depura��o

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
