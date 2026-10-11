using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.5f;
    [SerializeField] float shakeMagnitude = 0.1f;

    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition; // Store the initial position of the camera
    }

    public void Play()
    {
        StartCoroutine(ShakeCamera()); // Start the camera shake coroutine
    }

    IEnumerator ShakeCamera()
    {
        float timeElapsed = 0f;
        while (timeElapsed < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude; // Apply a random offset to the camera's position
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame(); // Wait for a short delay before starting the shake
        }
        transform.position = initialPosition;
    }
}
