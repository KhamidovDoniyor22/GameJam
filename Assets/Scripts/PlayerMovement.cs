using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private bool doubleJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (!doubleJump)
            {
                doubleJump = true;
                Jump();
            }
        }
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 move = transform.right * moveInput * moveSpeed;

        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, rb.linearVelocity.z);

        PlayerAnimation.Instance.RunAnimation(true);
        PlayerAnimation.Instance.JumpAnimation(false);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        PlayerAnimation.Instance.RunAnimation(false);
        PlayerAnimation.Instance.JumpAnimation(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            doubleJump = false;
            PlayerAnimation.Instance.JumpAnimation(false);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }
}