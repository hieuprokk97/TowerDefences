using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Cryptography;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemyAlive;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountDownText;

    public GameManager gameManager;

    private int waveIndex = 0;
    void Update()
    {
        if (EnemyAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            if (waveIndex == waves.Length)
            {
                gameManager.WinLevel();
                this.enabled = false;
            }
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countdown);     
    }
    IEnumerator SpawnWave()
    {
        
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemyAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveIndex++;


    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}

