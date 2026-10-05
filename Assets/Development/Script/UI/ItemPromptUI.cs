using TMPro;
using UnityEngine;

public class ItemPromptUI : MonoBehaviour
{
    [SerializeField] private GameObject promptPanel;
    [SerializeField] private TextMeshProUGUI promptText;

    private void Start()
    {
        if (promptPanel != null)
        {
            promptPanel.SetActive(false);
        }
    }

    public void Show(string message)
    {
        if (promptPanel == null)
        {
            return;
        }
        promptText.text = message;
        promptPanel.SetActive(true);
    }

    public void Hide()
    {
        if (promptPanel == null)
        {
            return;
        }
        promptPanel.SetActive(false);
    }
}
