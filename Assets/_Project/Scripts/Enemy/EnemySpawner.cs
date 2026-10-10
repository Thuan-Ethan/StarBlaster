using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO[] waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    WaveConfigSO  currentWave;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        foreach (WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(
                    currentWave.GetEnemyPrefab(0), 
                    currentWave.GetStartingWaypoints().position,
                    Quaternion.identity, 
                    transform);

                yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
