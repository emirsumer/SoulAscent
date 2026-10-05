using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageText;

    public void UpdateDamage(float currentDamage)
    {
        damageText.text = "Damage: " + currentDamage.ToString("0");
    }
}
