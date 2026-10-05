using System.Collections;
using UnityEngine;

public partial class CharacterController
{
    [SerializeField] private ParticleSystem deathEffect;
    [SerializeField] private float hitStunDuration = 0.5f;
    [SerializeField] private float maxHealth = 100f;
    public bool IsHit { get; private set; }

    private float _health = 100;

    private void InitHealth() 
    {
        if (GameData.Instance != null)
        {
            GameData.Instance.SetDefaultValues(maxHealth, attackPoint.GetDamage()); // Baþlangýç can ve hasarý hafýzaya kaydet
            _health = GameData.Instance.Health;                   // Kayýtlý caný yükle
            attackPoint.SetDamage(GameData.Instance.Damage);      // Kayýtlý hasarý karaktere yükle
        }

        UIManager.Instance.StartHealth(maxHealth);
        UIManager.Instance.RefreshHealth(_health);
        UIManager.Instance.StartDamage(attackPoint.GetDamage());
        UIManager.Instance.StartScore(GameData.Instance != null ? GameData.Instance.Score : 0); // GameData varsa skoru al, yoksa 0
    }
    public void OnDamage(float damageAmount)                      // IDamageable
    {
        _health -= damageAmount;
        UIManager.Instance.RefreshHealth(_health);

        if (_health <= 0)
        {
            Die();
            return;
        }

        TriggerHit();
    }
    private void TriggerHit()
    {
        StopMovement();                                           
        AnimHit();                                                
        StartCoroutine(HitStunCoroutine());
    }
    public void PlayHitSound()                                
    {
        SoundManager.Instance.PlayCharacterHitSFX();
    }
    private IEnumerator HitStunCoroutine()
    {
        IsHit = true;
        yield return new WaitForSeconds(hitStunDuration);
        IsHit = false;
    }
    public void AddHealth(float amount)                           
    {
        _health += amount;

        if (_health > maxHealth)                                 
        {
            _health = maxHealth;
        }

        UIManager.Instance.RefreshHealth(_health);
    }
    public void ReduceHealth(float amount)                        
    {
        _health -= amount;
        UIManager.Instance.RefreshHealth(_health);

        if (_health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        AnimDeath();
        _rigidbody2D.linearVelocity = Vector2.zero;
    }
    public void OnDeathAnimationEnd()                             
    {
        SoundManager.Instance.PlayCharacterDeathSFX();
        UIManager.Instance.EndGame();                            
        deathEffect.Play();
        deathEffect.transform.parent = null;                     
        deathEffect.transform.localScale = Vector3.one;
        Destroy(gameObject);
    }
}
