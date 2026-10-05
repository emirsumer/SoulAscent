using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private DamageUI damageUI;
    [SerializeField] private ItemPopupUI itemPopupUI;
    [SerializeField] private ItemPromptUI itemPromptUI;
    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private ScoreUI scoreUI;
    [SerializeField] private ItemCounterUI itemCounterUI;
    [SerializeField] private VictoryUI victoryUI;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }
    private void Start()
    {
        if (GameData.Instance != null)
        {
            StartHealth(GameData.Instance.Health);
            StartDamage(GameData.Instance.Damage);
            StartScore(GameData.Instance.Score);
        }
    }

    public void StartHealth(float maxHealth)
    {
        healthUI.SetMaxHealth(maxHealth);
    }
    public void RefreshHealth(float currentHealth)
    {
        healthUI.UpdateHealth(currentHealth);

        if (GameData.Instance != null)
        {
            GameData.Instance.Health = currentHealth;
        }
    }

    public void StartDamage(float currentDamage)
    {
        damageUI.UpdateDamage(currentDamage);
    }

    public void RefreshDamage(float currentDamage)
    {
        damageUI.UpdateDamage(currentDamage);

        if (GameData.Instance != null)
        {
            GameData.Instance.Damage = currentDamage;
        }
    }

    public void ShowItemPopup(string message)
    {
        itemPopupUI.ShowMessage(message);
    }

    public void ShowItemPrompt(string message)
    {
        itemPromptUI.Show(message);
    }

    public void HideItemPrompt()
    {
        itemPromptUI.Hide();
    }

    public void EndGame()
    {
        gameOverUI.Open();
    }

    public void StartScore(int score)
    {
        scoreUI.SetScore(score);
    }

    public void AddScore(int amount)
    {
        scoreUI.AddScore(amount);

        if (GameData.Instance != null)
        {
            GameData.Instance.Score += amount;
        }
    }

    public void UpdateItemCount(int count)
    {
        itemCounterUI.UpdateCount(count);
    }

    public void ShowVictory()
    {
        victoryUI.Open();
    }
}
