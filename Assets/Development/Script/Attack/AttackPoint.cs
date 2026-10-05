using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private float damage = 20f;
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
    }

    public void EnableHitbox()
    {
        _collider.enabled = true;
    }

    public void DisableHitbox()
    {
        _collider.enabled = false;
    }

    public void UpdateDamage(float amount)
    {
        damage += amount;
        damage = Mathf.Max(damage, 1f);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float value)
    {
        damage = value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.root == transform.root)
        { 
            return; // Karakterin kendi silahýyla kendisine hasar vermesini engeller.
        }

        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.OnDamage(damage);
        }
    }
}