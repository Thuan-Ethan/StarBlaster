using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    
    [SerializeField] float enemySpeed = 10f;
    [SerializeField] private float timeBetweenEnemiesSpawns = 1f;
    [SerializeField] private float enemySpawnVariance = 0f; 
    [SerializeField] private float minimumSpawnTime = 0.2f;

    public Transform GetStartingWaypoints()
    {
        return pathPrefab.GetChild(0);
    }

    public float GetEnemySpeed()
    {
        return enemySpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public Transform[] GetWaypoint()
    {
        Transform[] waypoints = new Transform[pathPrefab.childCount];
        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            waypoints[i] = pathPrefab.GetChild(i);
        }
        return waypoints;
    }
    
    public float GetRandomEnemySpawnTime()
    {
        float spawnTime = Random.Range(
            timeBetweenEnemiesSpawns - enemySpawnVariance,
            timeBetweenEnemiesSpawns +  minimumSpawnTime);
        
        spawnTime = Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
        return spawnTime;
    }
}
