using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class UIScript : MonoBehaviour
{
    public static UIScript Instance;
    [SerializeField] private GameObject receiptPanel;
    [SerializeField] private Text _livesText;
    [SerializeField] private int _seconds;
    [SerializeField] private Text _TimerSeconds;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private AudioClip _clipLose;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        receiptPanel.SetActive(true);
        _livesText.text = "Lives " + 3;
        _TimerSeconds.text = "Timer " + _seconds;
        TimerCountDown();
    }
    public void PanelOpen(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void PanelClose(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void UpdateLives(int playerHealth)
    {
        _livesText.text = "Lives " + playerHealth.ToString();
        if (playerHealth < 1)
        { GameOver(); }
    }

    private void GameOver()
    {
        Debug.Log("Lose");
        losePanel.SetActive(true);
        AudioSource.PlayClipAtPoint(_clipLose, transform.position);
    }

    public void TimerCountDown()
    {
        StartCoroutine(TimerCounter());
    }


    IEnumerator TimerCounter()
    {
        while (_seconds > 0)
        {
            yield return new WaitForSeconds(1);
            _seconds--;
            _TimerSeconds.text = "Timer " + _seconds;
        }
        GameOver();
    }

    #region Next_levels

    public void MainMenu()
    { SceneManager.LoadScene(0); }

    public void SecondLevel()
    {SceneManager.LoadScene(2);}

    public void ThirdLevel()
    {SceneManager.LoadScene(3);}

    public void FourthLevel()
    {SceneManager.LoadScene(4);}

    public void ThanksCredit()
    {SceneManager.LoadScene(5);}

    #endregion
}