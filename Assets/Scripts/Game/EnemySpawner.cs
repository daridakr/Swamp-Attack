using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _spawnWaves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Hero _target;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _elapsedTime = 0;
    private int _spawnedNumber = 0;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawnedNumber++;
            _elapsedTime = 0;
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Prefab, _spawnPoint.position, _spawnPoint.localRotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
    }

    private void SetWave(int waveNumber)
    {
        _currentWave = _spawnWaves[waveNumber];
    }
}

[System.Serializable]
public class Wave
{
    public Enemy Prefab;
    public float Delay;
    public int Count;
}
