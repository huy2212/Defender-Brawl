using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    Easy,
    Normal,
    Hard
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private Difficulty _difficulty;
    private float _spawnInterval;
    private int _enemiesPerWave;

    private void StartNewWave()
    {
        switch (_difficulty)
        {
            case Difficulty.Easy:
                _spawnInterval = UnityEngine.Random.Range(9, 10);
                _enemiesPerWave = UnityEngine.Random.Range(1, 2);
                break;
            case Difficulty.Normal:
                _spawnInterval = UnityEngine.Random.Range(8, 9);
                _enemiesPerWave = UnityEngine.Random.Range(1, 2);
                break;
            case Difficulty.Hard:
                _spawnInterval = UnityEngine.Random.Range(6, 7);
                _enemiesPerWave = UnityEngine.Random.Range(3, 4);
                break;
        }
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(_spawnInterval);
        for (int i = 0; i < _enemiesPerWave; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, _enemyPrefabs.Count);
            GameObject enemy = Instantiate(_enemyPrefabs[randomIndex], transform.position, transform.rotation);
            StartNewWave();
        }
    }

    private void Start()
    {
        StartNewWave();
    }
}
