using System.Collections.Generic;
using UnityEngine;

public class PlayerArsenal : MonoBehaviour
{
    public static PlayerArsenal Instance;

    [SerializeField] private string[] levelGoals;
    [SerializeField] private int[] goalNumberValue;
    [SerializeField] private GameObject[] checkMarks;
    [SerializeField] private GameObject[] productToRemove;
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
    public void RemoveProduct()
    {
        bool isRandomize = false;
        for(int i = 0; i < goalNumberValue.Length; i++)
        {
            if(goalNumberValue[i] > 0)
            {
                isRandomize = true;
            }
        }
        if(isRandomize)
        {
            while (true)
            {
                int randomProduct = Random.Range(0, goalNumberValue.Length);
                if (goalNumberValue[randomProduct] > 0)
                {
                    Debug.Log(randomProduct);
                    goalNumberValue[randomProduct] = 0;
                    checkMarks[randomProduct].SetActive(false);
                    SpawnFlyProduct(randomProduct);
                    break;
                }
            }
        }
        
    }
    private void SpawnFlyProduct(int index)
    {
        GameObject newProduct = Instantiate(productToRemove[index], gameObject.transform.position, Quaternion.identity);
        Destroy(newProduct, 1f);
    }
}
