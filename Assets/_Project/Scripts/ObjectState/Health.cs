using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the Object hit a Damage dealer
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            // Reduce the health by the damage amount
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
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
}
