using UnityEngine;
using System.Collections;
public class SimpleCharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1f;
    private Rigidbody rb;
    [SerializeField] private int _lives = 3;
    private Renderer _mesh;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _mesh = GetComponent<Renderer>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Use "A" and "D" or arrow keys for left-right movement
        Vector3 move = new Vector3(moveInput, 0, 0);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void Damage()
    {
        _lives -= 1;
        Debug.Log("Player damage");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red_Platform"))
        {
            Damage();
            StartCoroutine(Wait());
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(ToggleMeshVisibility());
        }
    }

    IEnumerator ToggleMeshVisibility()
    {
        for (int i = 0; i < 5; i++)
        {
            _mesh.enabled = false;
            yield return new WaitForSeconds(0.1f);  // Adjust time as needed
            _mesh.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        // After 2 seconds, you could perform additional actions if needed, such as hiding the platform
    }
}
