using UnityEngine;
using System.Collections;
public class SimpleCharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1f;
    private Rigidbody rb;
    [SerializeField] private int _lives = 3;
    private Renderer _mesh;
    private UI _uiManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _mesh = GetComponent<Renderer>();
        _uiManager = GameObject.Find("UI").GetComponent<UI>();
        if (_uiManager == null)
        {
            Debug.LogError("Debug  UI manager is null");
        }
    }

    void Update()
    {
        Move();
        Jump();
        isFalledDown();

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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red_Platform"))
        {
            TakingDamage();
        }
    }

    void isFalledDown()
    {
        if (transform.position.y < -2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            TakingDamage(2);
            StartCoroutine(Wait());
        }
    }
    void TakingDamage(int multiplyer = 2)
    {
        _lives--;
        _uiManager.UpdateLives(_lives);
        StartCoroutine(Wait());
        rb.AddForce(Vector3.up * multiplyer *jumpForce, ForceMode.Impulse);
        StartCoroutine(ToggleMeshVisibility());
    }

    IEnumerator ToggleMeshVisibility()
    {
        for (int i = 0; i < 5; i++)
        {
            _mesh.enabled = false;
            yield return new WaitForSeconds(0.1f);
            _mesh.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
