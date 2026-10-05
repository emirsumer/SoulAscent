using UnityEngine;

public partial class CharacterController
{
    private int _itemCount;
    public int ItemCount => _itemCount;

    public void CollectItem()
    {
        _itemCount++;
        UIManager.Instance.UpdateItemCount(_itemCount);
    }

    public void ApplyItemEffect(ItemEffectType type, float value)
    {
        switch (type)
        {
            case ItemEffectType.DamageUp:
                attackPoint.UpdateDamage(value);                  // attackPoint: Character_Combat.cs
                UIManager.Instance.RefreshDamage(attackPoint.GetDamage());
                UIManager.Instance.ShowItemPopup("+" + value + " Damage!");
                break;

            case ItemEffectType.DamageDown:
                attackPoint.UpdateDamage(-value);
                UIManager.Instance.RefreshDamage(attackPoint.GetDamage());
                UIManager.Instance.ShowItemPopup("-" + value + " Damage!");
                break;

            case ItemEffectType.HealthDown:
                ReduceHealth(value);                              // Character_Health.cs
                UIManager.Instance.ShowItemPopup("-" + value + " Health!");
                break;

            case ItemEffectType.HealthUp:
                AddHealth(value);                                 // Character_Health.cs
                UIManager.Instance.ShowItemPopup("+" + value + " Health!");
                break;
        }
    }
}
