using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Hero _target;
    [SerializeField] private List<Wave> _spawnWaves;
    
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private int _spawnedNumberInWave = 0;
    private float _elapsedTime = 0;
    
    public event UnityAction AllEnemyInWaveSpawned;

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
            _spawnedNumberInWave++;
            _elapsedTime = 0;
        }

        if(_currentWave.Count <= _spawnedNumberInWave)
        {
            if (_spawnWaves.Count > _currentWaveNumber + 1)
            {
                AllEnemyInWaveSpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        int spawnPointNumber = Random.Range(0, _currentWave.Points.Length);
        Transform spawnPoint = _currentWave.Points[spawnPointNumber];

        Enemy enemy = Instantiate(_currentWave.Prefab, spawnPoint.position, spawnPoint.localRotation, spawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Died += OnEnemyDied;
    }

    private void SetWave(int waveNumber)
    {
        _currentWave = _spawnWaves[waveNumber];
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawnedNumberInWave = 0;
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
    public Transform[] Points;
    public int Count;
    public float Delay;
}
