using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    private Enemy _enemyTarget;
    [SerializeField] private float damage = 2f;
    [SerializeField] private float minDistanceToDealDamage = 0.1f;
    
    public 
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyTarget != null)
        {
            MoveProjecttile();
            RotateProjetile();
        }
    }

    private void MoveProjecttile()
    {
        transform.position = Vector2.MoveTowards(transform.position,_enemyTarget.transform.position,moveSpeed * Time.deltaTime);
        float distanceToTarget = (_enemyTarget.transform.position - transform.position).magnitude;
        if (distanceToTarget < minDistanceToDealDamage)
        {
            _enemyTarget.EnemyHealth.DealDamage(damage);
            ObjectPooler.ReturnToPool(gameObject);
            
        }
    }

    private void RotateProjetile()
    {
        Vector3 enemyPos = _enemyTarget.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
        transform.Rotate(0f,0f,angle);
    }

    public void SetEnemy(Enemy enemy)
    {
        _enemyTarget = enemy;
        
    }
}
