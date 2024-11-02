using UnityEngine;
using DG.Tweening;

public class PopEffect : MonoBehaviour
{
    public RectTransform panel;
    public GameObject receiptPanel;
    void Start()
    {
        panel.localScale = Vector3.zero;
    }
    private void OnEnable()
    {
        ShowPanel();
        Invoke(nameof(HidePanel), 1f);
    }
    public void ShowPanel()
    {
        panel.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    public void HidePanel()
    {
        panel.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
        Invoke(nameof(CloseReceiptPanelClose), 0.65f);
    }
    private void CloseReceiptPanelClose()
    {
        receiptPanel.SetActive(false);
    }
}
