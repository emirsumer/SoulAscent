using UnityEngine;

public partial class EnemyController
{
    [SerializeField] private AttackPoint attackPoint;         
    [SerializeField] private float attackCooldown;  

    public bool IsAttacking { get; private set; }                 

    private float _lastAttackTime = -999f;

    public bool TryAttack()
    {
        if (IsAttacking)
        {
            return false;
        }
        if (Time.time < _lastAttackTime + attackCooldown)         // Bekleme süresi dolmadýysa saldýrma
        {
            return false;
        }

        IsAttacking = true;
        _lastAttackTime = Time.time;
        AnimAttack();
        return true;
    }

    public void CancelAttack()
    {
        IsAttacking = false;
    }

    public void PlayAttackSound()
    {
        SoundManager.Instance.PlayEnemyAttackSFX();
    }

    public void OnAttackEnd()
    {
        IsAttacking = false;
    }

    public void OpenAttack()
    {
        attackPoint.EnableHitbox();
    }

    public void CloseAttack()
    {
        attackPoint.DisableHitbox();
    }
}
