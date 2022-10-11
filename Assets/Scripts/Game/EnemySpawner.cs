using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _spawnWaves;
    [SerializeField] private Hero _target;

    private Transform _spawnPoint;
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _elapsedTime = 0;
    private int _spawnedNumber = 0;

    private void Awake()
    {
        _spawnPoint = GetComponent<Transform>();
    }

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

        if(_currentWave.Count <= _spawnedNumber)
        {
            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Prefab, _spawnPoint.position, _spawnPoint.localRotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Died += OnEnemyDied;
    }

    private void SetWave(int waveNumber)
    {
        _currentWave = _spawnWaves[waveNumber];
    }

    private void OnEnemyDied(Enemy current)
    {
        current.Died -= OnEnemyDied;

        _target.AddMoney(current.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public Enemy Prefab;
    public float Delay;
    public int Count;
}
