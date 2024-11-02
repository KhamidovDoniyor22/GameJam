using UnityEngine;

public class PlayerArsenal : MonoBehaviour
{
    public static PlayerArsenal Instance;

    [SerializeField] private string[] levelGoals;
    [SerializeField] private int[] goalNumberValue;
    [SerializeField] private GameObject[] checkMarks;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        goalNumberValue = new int[levelGoals.Length];
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Product")
        {
            for(int i = 0; i < levelGoals.Length; i++)
            {
                if(levelGoals[i] == collision.gameObject.GetComponent<ProductData>().productName)
                {
                    goalNumberValue[collision.gameObject.GetComponent<ProductData>().productID]++;
                    checkMarks[collision.gameObject.GetComponent<ProductData>().productID].SetActive(true);
                    Destroy(collision.gameObject);

                }
            }          
        }       
    }
    public bool GoalCheck(int index)
    {
        if (goalNumberValue[index] > 0) return true;
        return false;
    }
}
