using UnityEngine;

public partial class CharacterController
{
    private void AnimMoveSpeed(float speed)
    {
        _animator.SetFloat("MoveSpeed", speed);
    }

    private void AnimJump()
    {
        _animator.SetTrigger("Jump");
    }

    private void AnimAttack1()
    {
        _animator.SetTrigger("Attack_1");
    }

    private void AnimAttack2()
    {
        _animator.SetTrigger("Attack_2");
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