using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem particle;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the Object hit a Damage dealer
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            // Reduce the health by the damage amount
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
            PlayHitParticles();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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
