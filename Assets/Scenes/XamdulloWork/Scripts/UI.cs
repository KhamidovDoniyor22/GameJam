using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Text _livesText;
    void Start()
    {
        _livesText.text = "Lives " + 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int playerScore)
    {
        _livesText.text = "Lives " + playerScore.ToString();
    }
}
