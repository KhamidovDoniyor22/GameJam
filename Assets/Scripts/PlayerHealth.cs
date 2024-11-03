using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    [SerializeField] private int health = 3;
    [SerializeField] private UIScript _uiManager;

    private Rigidbody rb;
    private Renderer _mesh;

    private void Start()
    {

        _mesh = GetComponent<Renderer>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIScript>();
        rb = GetComponent<Rigidbody>();
        if (_uiManager == null)
        {
            Debug.LogError("Debug  UI manager is null");
        }
    }

    void Update()
    {
        isFalledDown();
    }

    private void Awake()
    {
        Instance = this;
    }
    public void HealthDeacrease(int amount)
    {
        health -= amount;
    }
    public bool CheckHealth()
    {
        if (health > 0) return true;
        else return false;
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
            rb.linearVelocity = new Vector3(0, 0, 0);
            TakingDamage();
            StartCoroutine(Wait());
        }
    }
    void TakingDamage()
    {
        health--;
        _uiManager.UpdateLives(health);
        StartCoroutine(Wait());
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
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
