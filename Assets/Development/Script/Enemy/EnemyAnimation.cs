using UnityEngine;

public partial class EnemyController
{
    private void AnimMoveSpeed(float speed)
    {
        _animator.SetFloat("MoveSpeed", speed);
    }

    private void AnimAttack()
    {
        _animator.SetTrigger("Attack");
    }

    private void AnimHit()
    {
        _animator.SetTrigger("Hit");
    }

    private void AnimDeath()
    {
        _animator.SetTrigger("Death");
    }
}