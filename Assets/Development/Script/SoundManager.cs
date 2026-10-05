using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioSource menuMusic;
    [SerializeField] private AudioSource gameMusic;

    [Header("Character SFX")]
    [SerializeField] private AudioSource characterAttackSFX_1;
    [SerializeField] private AudioSource characterAttackSFX_2;
    [SerializeField] private AudioSource characterHitSFX;
    [SerializeField] private AudioSource characterDeathSFX;
    [SerializeField] private AudioSource jumpSFX;

    [Header("Enemy SFX")]
    [SerializeField] private AudioSource enemyAttackSFX;
    [SerializeField] private AudioSource enemyHitSFX;
    [SerializeField] private AudioSource enemyDeathSFX;

    [Header("Game SFX")]
    [SerializeField] private AudioSource itemPickupSFX;
    [SerializeField] private AudioSource buttonClickSFX;
    [SerializeField] private AudioSource gameOverSFX;
    [SerializeField] private AudioSource victorySFX;
    [SerializeField] private AudioSource levelUpSFX;

    public static SoundManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SetupMusicLoop();
    }
    private void SetupMusicLoop()
    {
        if (menuMusic != null)
        {
            menuMusic.loop = true;
        }
        
        if (gameMusic != null)
        {
            gameMusic.loop = true;
        }
    }
    public void PauseGameMusic()
    {
        if (gameMusic != null && gameMusic.isPlaying)
        {
            gameMusic.Pause();
        }
    }
    public void ResumeGameMusic()
    {
        if (gameMusic != null)
        {
            gameMusic.UnPause();
        }
    }
    public void PlayMenuMusic()
    {
        // Oyun müziði çalýyorsa durdur
        if (gameMusic != null && gameMusic.isPlaying)
        {
            gameMusic.Stop();
        }

        // Menü müziði atanmýþsa ve zaten çalmýyorsa baþlat
        if (menuMusic != null && !menuMusic.isPlaying)
        {
            menuMusic.Play();
        }
    }

    public void PlayGameMusic()
    {
        // Menü müziði çalýyorsa durdur
        if (menuMusic != null && menuMusic.isPlaying)
        {
            menuMusic.Stop();
        }

        // Oyun müziði atanmýþsa ve zaten çalmýyorsa baþlat
        if (gameMusic != null && !gameMusic.isPlaying)
        {
            gameMusic.Play();
        }
    }
    private void PlaySFX(AudioSource source)
    {
        if (source != null && source.clip != null)
        {
            source.PlayOneShot(source.clip);
        }
    }
    public void PlayCharacterAttackSFX_1()
    {
        PlaySFX(characterAttackSFX_1);
    }
    public void PlayCharacterAttackSFX_2()
    {
        PlaySFX(characterAttackSFX_2);
    }

    public void PlayCharacterHitSFX()
    {
        PlaySFX(characterHitSFX);
    }

    public void PlayCharacterDeathSFX()
    {
        PlaySFX(characterDeathSFX);
    }
    public void PlayJumpSFX()
    {
        PlaySFX(jumpSFX);
    }
    public void PlayEnemyAttackSFX()
    {
        PlaySFX(enemyAttackSFX);
    }

    public void PlayEnemyHitSFX()
    {
        PlaySFX(enemyHitSFX);
    }

    public void PlayEnemyDeathSFX()
    {
        PlaySFX(enemyDeathSFX);
    }
    public void PlayItemPickupSFX()
    {
        PlaySFX(itemPickupSFX);
    }

    public void PlayButtonClickSFX()
    {
        PlaySFX(buttonClickSFX);
    }

    public void PlayGameOverSFX()
    {
        PlaySFX(gameOverSFX);
    }

    public void PlayVictorySFX()
    {
        PlaySFX(victorySFX);
    }

    public void PlayLevelUpSFX()
    {
        PlaySFX(levelUpSFX);
    }
}

