using UnityEngine;

public class FinishCheck : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    public int levelGoal;
    private int levelIndex;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CheckResult(collision);         
        }
    }
    private void CheckResult(Collision collision)
    {
        for (int i = 0; i < levelGoal; i++)
        {

            if (collision.gameObject.GetComponent<PlayerArsenal>().GoalCheck(i))
            {            
                levelIndex += 1;
            }
        }
        if(levelIndex == levelGoal)
        {
            Debug.Log("WIN");
            winPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Lose");
            losePanel.SetActive(true);
        }
    }
}
