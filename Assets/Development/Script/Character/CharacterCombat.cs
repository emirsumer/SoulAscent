using UnityEngine;

public partial class CharacterController
{
    [SerializeField] private AttackPoint attackPoint;

    public void HandleAttack()
    {
        if (InputManager.Instance.Attack1Pressed)
        {
            AnimAttack1();
        }
        else if (InputManager.Instance.Attack2Pressed)
        {
            AnimAttack2();
        }
    }

    public void PlayAttackSound1()
    {
        SoundManager.Instance.PlayCharacterAttackSFX_1();
    }

    public void PlayAttackSound2()
    {
        SoundManager.Instance.PlayCharacterAttackSFX_2();
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
