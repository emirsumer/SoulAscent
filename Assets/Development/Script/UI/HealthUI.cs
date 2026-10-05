using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    public void SetMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void UpdateHealth(float currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}
