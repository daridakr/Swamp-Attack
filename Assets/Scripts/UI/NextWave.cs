using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private Button _nextWaveButton;

    private void OnEnable()
    {
        _spawner.AllEnemyInWaveSpawned += OnAllEnemyInWaveSpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemyInWaveSpawned -= OnAllEnemyInWaveSpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void OnAllEnemyInWaveSpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    public void OnNextWaveButtonClick()
    {
        _spawner.NextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}
