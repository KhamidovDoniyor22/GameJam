using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float startingX;
    [SerializeField] private float endingX;
    [SerializeField] private float speed = 5f;
    private bool movingForward = true;
    private bool isWaiting = false;

    void Start()
    {
        transform.position = new Vector3(startingX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (!isWaiting)
        {
            if (movingForward)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (transform.position.x >= endingX)
                {
                    movingForward = false;
                    StartCoroutine(PlatformWaits());
                }
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (transform.position.x <= startingX)
                {
                    movingForward = true;
                    StartCoroutine(PlatformWaits());
                }
            }
        }
    }

    IEnumerator PlatformWaits()
    {
        isWaiting = true;
        yield return new WaitForSeconds(3);
        isWaiting = false;
    }
}