using System.Collections;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject powerupPrefab; // Refer�ncia ao prefab do powerup
    public float powerupSpawnTime = 10f; // Tempo para spawnar o powerup ap�s o in�cio do jogo

    // Evento para notificar as bolas vermelhas sobre a mudan�a de tamanho
    public static event System.Action OnPowerupCollected;
    public static event System.Action OnPowerupEnded;

    void Start()
    {
        StartCoroutine(SpawnPowerupAfterDelay());
    }

    private IEnumerator SpawnPowerupAfterDelay()
    {
        yield return new WaitForSeconds(powerupSpawnTime);
        Instantiate(powerupPrefab, new Vector2(Random.Range(-7, 7), Random.Range(-4, 4)), Quaternion.identity);
    }

    public void PowerupCollected()
    {
        // Dispara o evento para notificar que o powerup foi coletado
        if (OnPowerupCollected != null)
        {
            OnPowerupCollected();
        }

        // Inicia a contagem para restaurar o tamanho original ap�s 10 segundos
        StartCoroutine(RestoreRedBallSizeAfterDelay());
    }

    private IEnumerator RestoreRedBallSizeAfterDelay()
    {
        yield return new WaitForSeconds(10f);

        // Dispara o evento para notificar que o efeito do powerup acabou
        if (OnPowerupEnded != null)
        {
            OnPowerupEnded();
        }
    }
}
