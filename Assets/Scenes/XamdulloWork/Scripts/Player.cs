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
}
