using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float currentScore;

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
