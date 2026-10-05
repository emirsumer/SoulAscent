using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;

    private void Start()
    {
        if (mainPanel != null)
        {
            mainPanel.SetActive(true);
        }

        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }

        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayMenuMusic();
        }

    }

    public void OpenSettings()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
