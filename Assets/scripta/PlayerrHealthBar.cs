using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = playerHealth.MaxHealth;
        slider.value = playerHealth.CurrentHealth;
    }

    private void AddListener(Action<float, float> updateHealthBar)
    {
        throw new NotImplementedException();
    }

    private void UpdateHealthBar(float current, float max)
    {
        slider.maxValue = max;
        slider.value = current;
    }
}
