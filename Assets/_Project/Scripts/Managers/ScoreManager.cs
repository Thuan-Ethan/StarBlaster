using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float currentScore;

    static ScoreManager instance;

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int instanceCount = FindObjectsByType<AudioManager>(FindObjectsInactive.Include).Length;
        //if(instanceCount > 1)
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public float GetScore()
    {
        return currentScore;
    }

    public void ModifyScore(float scoreToAdd)
    {
        currentScore += scoreToAdd;
        currentScore = Mathf.Clamp(currentScore, 0, float.MaxValue);
        Debug.Log(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
