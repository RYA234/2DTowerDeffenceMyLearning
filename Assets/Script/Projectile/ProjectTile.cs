using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    private Enemy _enemyTarget;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyTarget != null)
        {
            MoveProjecttile();
        }
    }

    private void MoveProjecttile()
    {
        transform.position = Vector2.MoveTowards(transform.position,_enemyTarget.transform.position,moveSpeed * Time.deltaTime);
    }

    public void SetEnemy(Enemy enemy)
    {
        _enemyTarget = enemy;
        
    }
}
