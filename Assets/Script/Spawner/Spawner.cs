using System;
using System.Collections;
using UnityEngine;


    public class Spawner : MonoBehaviour
    {
        [SerializeField]  private  int enemyCount = 10;
        // Btw = Between
        [SerializeField] private float delayBtwSpawns;
        [SerializeField] private float delayBtwWaves = 1f;

        private int _enemiesRemaining;
        
        private int _enemiesSpawned;
        private float _spawnTimer;
        private ObjectPooler _objectPooler;
        private Waypoint _waypoint;

        private void Start()
        {
            _objectPooler = GetComponent<ObjectPooler>();
            _waypoint = GetComponent<Waypoint>();
            
            _enemiesRemaining = enemyCount;
        }

        private void Update()
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer < 0)
            {
                _spawnTimer = delayBtwSpawns;
                if (_enemiesSpawned < enemyCount)
                {
                    SpawnEnemy();
                    _enemiesSpawned++;
                }
            }
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private void SpawnEnemy()
        {
            GameObject newInstance = _objectPooler.GetInstanceFromPool();
            Enemy enemy = newInstance.GetComponent<Enemy>();
            enemy.Waypoint = _waypoint;
            enemy.transform.localPosition = transform.position;
            enemy.ResetEnemy();
            newInstance.SetActive(true);
        }

        private IEnumerator NextWave()
        {
            yield return new WaitForSeconds(delayBtwWaves);
            _enemiesRemaining = enemyCount;
            _spawnTimer = 0f;
            _enemiesSpawned = 0;

        }
        
        private void RecordEnemy()
        {
            _enemiesRemaining--;
            if (_enemiesRemaining <= 0)
            {
                StartCoroutine(NextWave());
            }
        }

        private void OnEnable()
        {
            Enemy.OnEndReached += RecordEnemy;
            EnemyHealth.OnEnemyKilled += RecordEnemy;
        }


        private void OnDisable()
        {
            Enemy.OnEndReached -= RecordEnemy;
            EnemyHealth.OnEnemyKilled -= RecordEnemy;
        }
    }
