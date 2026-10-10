using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    Transform[] waypoints;

    private int waypointIndex = 0;
    void Start()
    {
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
    }
}
