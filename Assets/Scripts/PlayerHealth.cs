using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    [SerializeField] private int health = 3;
    [SerializeField] private UIScript _uiManager;

    private Rigidbody rb;
    private Renderer _mesh;
    private bool isFalledBool = false;
    private bool hasTakenDamage = false;

    private void Start()
    {

        _mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIScript>();
        rb = GetComponent<Rigidbody>();
        if (_uiManager == null)
        {
            Debug.LogError("Debug  UI manager is null");
        }
        if (_mesh == null)
        {
            Debug.LogError("Debug  skinned mesh  rendere is null");
        }
    }

    void Update()
    {
        isFalledDown();
        if (health < 1)
        { Destroy(this.gameObject); }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red_Platform"))
        {
            TakingDamage();
            PlayerArsenal.Instance.RemoveProduct();
        }
    }



    void isFalledDown()
    {
        if (transform.position.y < -3.5f)
        {
            isFalledBool = true;
        }
        else
        {
            isFalledBool = false;
            hasTakenDamage = false; // Reset the damage flag when the player is above the threshold
        }

        // Check if the player is falling and has not taken damage yet
        if (isFalledBool && !hasTakenDamage)
        {
            TakingDamage(2);
            hasTakenDamage = true;
            rb.linearVelocity = new Vector3(0, 0, 0);
            StartCoroutine(Wait());
        }
    }
    void TakingDamage(int multiplier = 1)
    {
        Debug.Log("DAMAGE");
        health--;
        _uiManager.UpdateLives(health);
        StartCoroutine(Wait());
        rb.AddForce(Vector3.up * 12 * multiplier, ForceMode.Impulse);
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
        yield return new WaitForSeconds(3);
    }

}
