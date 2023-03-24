using System;
using UnityEngine;


    public class Spawner : MonoBehaviour
    {
        [SerializeField]  private  int enemyCount = 10;
        // Btw = Between
        [SerializeField] private float delayBtwSpawns;

        private int _enemiesSpawned;
        private float _spawnTimer;
        private ObjectPooler _objectPooler;

        private void Start()
        {
            _objectPooler = GetComponent<ObjectPooler>();
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
        
        private void SpawnEnemy()
        {
            GameObject newInstance = _objectPooler.GetInstanceFromPool();
            newInstance.SetActive(true);
        }
        
    }
