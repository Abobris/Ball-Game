using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public float timeToWait = 30f; // Tempo em segundos para esperar antes da transição

    void Start()
    {
        StartCoroutine(TransitionToNextScene());
    }

    private IEnumerator TransitionToNextScene()
    {
        // Aguarda o tempo definido
        yield return new WaitForSeconds(timeToWait);

        // Verifica a cena atual e decide para onde transitar
        if (SceneManager.GetActiveScene().name == "MainGame")
        {
            SceneManager.LoadScene("MainGame 2");
        }
        else if (SceneManager.GetActiveScene().name == "MainGame 2")
        {
            SceneManager.LoadScene("FinalScene");
        }
    }
}