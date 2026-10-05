using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    public void SetMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void UpdateHealth(float currentHealth)
    {
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        healthSlider.value = currentHealth;
    }
}
