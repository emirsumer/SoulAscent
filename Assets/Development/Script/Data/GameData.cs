using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    private bool _isSet;
    private float _defaultHealth;
    private float _defaultDamage;

    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private int score;
    public float Health
    {
        get => health;
        set => health = value;
    }

    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    public int Score
    {
        get => score;
        set => score = value;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetDefaultValues(float startHealth, float startDamage)
    {
        if (_isSet)
        {
            return;
        } 

        _defaultHealth = startHealth;
        _defaultDamage = startDamage;
        Health = startHealth;
        Damage = startDamage;
        Score = 0;
        _isSet = true;
    }

    public void ResetAll()
    {
        Health = _defaultHealth;
        Damage = _defaultDamage;
        Score = 0;
    }

    public void ResetHealthForNextLevel()
    {
        Health = _defaultHealth;
    }
}
