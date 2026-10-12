using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [SerializeField] TextMeshProUGUI scoreText;
    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();

        if (healthSlider != null && playerHealth != null)
        {
            healthSlider.maxValue = playerHealth.GetHealth();
        }
    }

    private void Update()
    {

        scoreText.text =
            scoreManager.GetScore().ToString("00000000");

        healthSlider.value = playerHealth.GetHealth();

    }
}
