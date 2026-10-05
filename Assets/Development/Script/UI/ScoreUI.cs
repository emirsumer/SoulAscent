using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int _totalScore;

    private void Start()
    {
        scoreText.text = "Score: " + _totalScore;
    }
    public void SetScore(int score)
    {
        _totalScore = score;
        scoreText.text = "Score: " + _totalScore;
    }
    public void AddScore(int amount)
    {
        _totalScore += amount;
        scoreText.text = "Score: " + _totalScore;
    }
}
