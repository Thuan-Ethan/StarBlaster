using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletLifetime = 5f;
    [SerializeField] float fireRate = 0.2f;

    public bool isFiring = false;
    Coroutine fireCoroutine;

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
            Destroy(bullet, bulletLifetime);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(0, bulletSpeed);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
