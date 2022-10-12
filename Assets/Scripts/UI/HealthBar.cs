using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Hero _target;

    private void OnEnable()
    {
        _target.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _target.HealthChanged -= OnValueChanged;
    }
}
