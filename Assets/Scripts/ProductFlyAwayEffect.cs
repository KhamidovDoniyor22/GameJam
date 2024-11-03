using UnityEngine;

public class ProductFlyAwayEffect : MonoBehaviour
{
    public float launchForce = 5f;         
    public float blinkInterval = 0.1f;    
    public bool flyRight = true;        
    private Renderer objRenderer;
    private Rigidbody rb;
    private bool isBlinking = false;      

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        objRenderer = GetComponent<Renderer>();

        if (rb != null)
        {
            Vector3 launchDirection = flyRight ? Vector3.right : Vector3.left;
            rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isBlinking && collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isBlinking = true;
            rb.isKinematic = true;
            InvokeRepeating("Blink", 0f, blinkInterval);
        }
    }

    private void Blink()
    {
        if (objRenderer != null)
        {
            objRenderer.enabled = !objRenderer.enabled;
        }
    }
}
