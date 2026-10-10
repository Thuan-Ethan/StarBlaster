using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemySpeed = 10f;

    public Transform GetStartingWaypoints()
    {
        return pathPrefab.GetChild(0);
    }

    public float GetEnemySpeed()
    {
        return enemySpeed;
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
}
