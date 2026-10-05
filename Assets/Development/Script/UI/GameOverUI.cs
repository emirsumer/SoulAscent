using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void Open()
    {
        SoundManager.Instance.PlayGameOverSFX();
        gameOverPanel.SetActive(true);
    }
}
