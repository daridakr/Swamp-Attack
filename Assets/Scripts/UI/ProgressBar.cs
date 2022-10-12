using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private EnemySpawner _target;

    private void OnEnable()
    {
        _target.EnemyCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _target.EnemyCountChanged -= OnValueChanged;
    }
}
