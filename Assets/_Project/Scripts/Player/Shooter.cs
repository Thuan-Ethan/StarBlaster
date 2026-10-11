using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletLifetime = 5f;
    [SerializeField] float baseFireRate = 0.2f;

    [Header("AI Variables")]
    [SerializeField] float minimumFireRate = 0.2f;
    [SerializeField] float fireRateVariance = 0f;
    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring = false;
    Coroutine fireCoroutine;


    private void Start()
    {
        if (useAI)
        {
            isFiring = true; // Start firing bullets automatically if using AI
        }
    }

    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null) // Start firing bullets if not already firing
        {
            // Repeatly fire bullets at the specified fire rate
            fireCoroutine = StartCoroutine(FireContinuously());
        } else if (!isFiring && fireCoroutine != null) // Stop firing bullets if currently firing
        {
            // Stop firing bullets
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            bullet.transform.rotation = transform.rotation; // Set the bullet's rotation to match the shooter's rotation

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.up * bulletSpeed; // Set the bullet's velocity in the direction the shooter is facing

            Destroy(bullet, bulletLifetime); // Destroy the bullet after its lifetime expires

            float fireRate = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance); // Randomize the fire rate between 0.1 and 0.5 seconds
            fireRate = Mathf.Clamp(fireRate, minimumFireRate, float.MaxValue); // Clamp the fire rate to a minimum value of 0.1 seconds

            yield return new WaitForSeconds(fireRate);
        }
    }
}
