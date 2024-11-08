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
        // Carrega a pontua��o m�xima usando PlayerPrefs
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // O segundo par�metro � o valor padr�o (0)
        highScoreText.text = "Pontua��o M�xima: " + highScore.ToString();
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
