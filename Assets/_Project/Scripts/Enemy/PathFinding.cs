using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;

    private EnemySpawner _enemySpawner;
    Transform[] waypoints;

    private int waypointIndex = 0;
    void Start()
    {
        _enemySpawner = FindAnyObjectByType<EnemySpawner>();
        waveConfig = _enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoint();
        transform.position = waveConfig.GetStartingWaypoints().position;
    }

    void Update()
    {   
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float moveDelta = waveConfig.GetEnemySpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition ,moveDelta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
