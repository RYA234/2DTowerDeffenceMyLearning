using UnityEngine;


    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject testGO;
        [SerializeField]  private  int enemyCount = 10;
        // Btw = Between
        [SerializeField] private float delayBtwSpawns;

        private int _enemiesSpawned;
        private float _spawnTimer;
        
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
            Instantiate(testGO, transform.position, Quaternion.identity);
        }
        
    }
