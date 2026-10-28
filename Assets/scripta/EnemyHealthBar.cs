using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Health enemyHealth;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = enemyHealth.MaxHealth;
        slider.value = enemyHealth.CurrentHealth;
    }

    private void UpdateHealthBar(float current, float max)
    {
        slider.value = current;
    }
}
