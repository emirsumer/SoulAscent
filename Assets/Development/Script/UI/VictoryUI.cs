using UnityEngine;

public class VictoryUI : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    private void Start()
    {
        victoryPanel.SetActive(false);
    }

    public void Open()
    {
        SoundManager.Instance.PlayVictorySFX();
        Time.timeScale = 0;
        victoryPanel.SetActive(true);
    }
}
