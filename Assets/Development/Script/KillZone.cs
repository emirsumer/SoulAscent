using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private float damage = 100f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterController character = collision.GetComponent<CharacterController>();
        if (character != null)
        {
            SoundManager.Instance.PlayCharacterHitSFX();
            character.OnDamage(damage);
        }
    }
}
