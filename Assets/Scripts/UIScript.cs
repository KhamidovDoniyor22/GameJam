using UnityEngine;
using UnityEngine.SceneManagement;
public class UIScript : MonoBehaviour
{
    public static UIScript Instance;
    [SerializeField] private GameObject receiptPanel;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        receiptPanel.SetActive(true);
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
}
