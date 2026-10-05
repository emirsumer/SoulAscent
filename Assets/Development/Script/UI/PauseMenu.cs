using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseObjects;
    [SerializeField] private GameObject buttonsPanel;
    [SerializeField] private GameObject settingsPanel;

    private bool _isPaused;

    private void Update()
    {
        if (InputManager.Instance.PausePressed)
        {
            if (_isPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        _isPaused = true;
        pauseObjects.SetActive(true);
        buttonsPanel.SetActive(true);
        settingsPanel.SetActive(false);
        SoundManager.Instance.PauseGameMusic();
        Time.timeScale = 0;
    }

    public void Resume()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        _isPaused = false;
        pauseObjects.SetActive(false);
        SoundManager.Instance.ResumeGameMusic();
        Time.timeScale = 1;
    }

    public void OpenSettings()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        buttonsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        buttonsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
