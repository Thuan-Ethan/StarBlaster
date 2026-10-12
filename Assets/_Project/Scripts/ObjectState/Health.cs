using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] float scoreValue = 50f;
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem particle;

    [SerializeField] bool applyCameraShake = false;
    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreManager scoreManager;
    LevelManager levelManager;

    private void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = FindAnyObjectByType<AudioManager>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    public int GetHealth()
    {
        return health;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the Object hit a Damage dealer
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            // Reduce the health by the damage amount
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
            audioManager.PlayDamageSFX();
            PlayHitParticles();

            if (applyCameraShake)
            {
                cameraShake.Play();
            }
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isPlayer)
        {
            levelManager.LoadGameOver();
        }
        else
        {
            scoreManager.ModifyScore(scoreValue);
        }
        Destroy(gameObject);
    }

    void PlayHitParticles()
    {
        if (particle != null)
        {
            ParticleSystem instance = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
