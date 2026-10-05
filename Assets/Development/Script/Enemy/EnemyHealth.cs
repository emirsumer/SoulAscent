using System.Collections;
using UnityEngine;

public partial class EnemyController
{
    [SerializeField] private ParticleSystem deathEffect;
    [SerializeField] private float health = 100f;

    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private float dropRate = 0.5f;

    [SerializeField] private float hitStunDuration;
    [SerializeField] private EnemyHealthUI healthBar;

    [SerializeField] private int scoreValue;

    public bool IsHit { get; private set; }

    private void InitHealth()                                 
    {
        healthBar.SetMaxHealth(health);
    }

    public void OnDamage(float damageAmount)            
    {
        health -= damageAmount;
        healthBar.UpdateHealth(health);

        if (health <= 0)
        {
            Die();
            return;
        }

        TriggerHit();
    }
    private void TriggerHit()
    {
        CancelAttack();                                        
        StopMoving();                                            
        AnimHit();                                              
        StartCoroutine(HitStunCoroutine());
    }

    public void PlayHitSound()
    {
        SoundManager.Instance.PlayEnemyHitSFX();
    }

    private IEnumerator HitStunCoroutine()
    {
        IsHit = true;
        yield return new WaitForSeconds(hitStunDuration);
        IsHit = false;
    }

    private void Die()
    {
        AnimDeath();
        _rigidbody2D.linearVelocity = Vector2.zero;
    }

    public void OnDeathAnimationEnd()   
    {
        SoundManager.Instance.PlayEnemyDeathSFX();
        UIManager.Instance.AddScore(scoreValue);
        deathEffect.Play();
        deathEffect.transform.parent = null;
        deathEffect.transform.localScale = Vector3.one;

        if (itemPrefabs.Length > 0)
        {
            if (Random.value <= dropRate)
            {
                GameObject chosenItem = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
                Instantiate(chosenItem, transform.position, Quaternion.identity);
            }
        }

        Destroy(gameObject);
    }
}
