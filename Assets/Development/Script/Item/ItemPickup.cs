using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private ItemEffectType effectType;
    [SerializeField] private float effectValue;

    private CharacterController _characterController;

    private void Update()
    {
        if (_characterController != null && InputManager.Instance.InteractPressed)
        {
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController characterItems = other.GetComponent<CharacterController>();
        if (characterItems != null)
        {
            _characterController = characterItems;
            UIManager.Instance.ShowItemPrompt(GetDescription());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CharacterController characterItems = other.GetComponent<CharacterController>();
        if (characterItems != null && characterItems == _characterController)
        {
            _characterController = null;
            UIManager.Instance.HideItemPrompt();
        }
    }

    private void PickUp()
    {
        _characterController.ApplyItemEffect(effectType, effectValue);
        _characterController.CollectItem();
        SoundManager.Instance.PlayItemPickupSFX();
        UIManager.Instance.HideItemPrompt();
        Destroy(gameObject);
    }

    private string GetDescription()
    {
        switch (effectType)
        {
            case ItemEffectType.DamageUp:
                return "+" + effectValue + " Damage  |  Press E";
            case ItemEffectType.DamageDown:
                return "-" + effectValue + " Damage  |  Press E";
            case ItemEffectType.HealthDown:
                return "-" + effectValue + " Health  |  Press E";
            case ItemEffectType.HealthUp:
                return "+" + effectValue + " Health  |  Press E";
            default:
                return "Press E";
        }
    }
}
