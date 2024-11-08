using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Para usar TextMeshPro
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText; // Atribua no Inspector

    void Start()
    {
        // Carrega a pontuação máxima usando PlayerPrefs
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // O segundo parâmetro é o valor padrão (0)
        highScoreText.text = "Pontuação Máxima: " + highScore.ToString();
    }

    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
