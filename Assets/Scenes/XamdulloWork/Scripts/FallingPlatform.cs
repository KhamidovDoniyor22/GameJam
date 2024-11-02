using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isDestroyed = false;
    private Rigidbody rb;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDestroyed)
        {
            StartCoroutine(RespawnPlatform());
        }
    }

    IEnumerator RespawnPlatform()
    {
        yield return new WaitForSeconds(2);
        rb.isKinematic = false;
        isDestroyed = true;

        // Wait for 2 seconds before respawning the platform
        Debug.Log("Starting timer before respawning platform.");
        yield return new WaitForSeconds(2);
        Debug.Log("Timer finished. Respawning platform.");

        Debug.Log("Platform respawned.");
        Reset();
    }

    void Reset()
    {

        transform.position = initialPosition;
        transform.rotation = initialRotation;

        rb.isKinematic = true;

        // Reset the destroyed flag
        isDestroyed = false;
    }
}