using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target; // The object the camera will orbit around
    public float orbitSpeed = 10f; // Speed of the orbit
    public float orbitRadius = 5f; // Distance from the target
    public float heightOffset = 2f; // Height offset from the target

    private Vector3 offset;

    void Start()
    {
        // Calculate the initial offset from the target
        offset = new Vector3(orbitRadius, heightOffset, 0);
    }

    void Update()
    {
        // Rotate the offset around the target
        offset = Quaternion.Euler(0, orbitSpeed * Time.deltaTime, 0) * offset;

        // Set the camera's position to the target's position plus the offset
        transform.position = target.position + offset;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
