using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName;
    [SerializeField] private string firstLevelSceneName;

    public static ButtonActions Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    public void PlayGame()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        SoundManager.Instance.PlayGameMusic();
        SceneManager.LoadScene(firstLevelSceneName);
    }
    public void Retry()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        ResetGameData();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NewGame()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        ResetGameData();
        Time.timeScale = 1;
        SceneManager.LoadScene(firstLevelSceneName);
    }

    public void GoToNextLevel(string sceneName)
    {
        if (GameData.Instance != null)
        {
            GameData.Instance.ResetHealthForNextLevel();
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void GoHome()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        ResetGameData();
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        SoundManager.Instance.PlayButtonClickSFX();
        Application.Quit();
    }

    private void ResetGameData()
    {
        if (GameData.Instance != null)
        {
            GameData.Instance.ResetAll();
        }
    }
}
