using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectTile : MonoBehaviour
{

    [SerializeField] protected Transform projecttileSpawnPosition;
    protected ObjectPooler _pooler;
    protected Turrets _turret;
    protected Projectile _currentProjectileLoaded;
    [SerializeField] protected float delayBtwAttacks = 0.3f;
    [SerializeField] protected float damage = 2f;
    public float Damage { get; set; }
    public float DelayPerShot { get; set; }
    
    protected float _nextAttackTime;
    
    private void Start()
    {
        _pooler = GetComponent<ObjectPooler>();
        _turret = GetComponent<Turrets>();

        Damage = damage;
        DelayPerShot = delayBtwAttacks;
        LoadProjecttile();
        
    }

    protected virtual void Update()
    {
        // if (Input.GetKeyDown(KeyCode.G))
        // {
        //     LoadProjecttile();
        // }
        if (IsTurrentEmpty())
        {
            LoadProjecttile();
        }
        
        if(Time.time > _nextAttackTime)
        {
            if (_turret.CurrentEnemyTarget != null && _currentProjectileLoaded != null &&
                _turret.CurrentEnemyTarget.EnemyHealth.CurrentHealth > 0f)
            {
                _currentProjectileLoaded.transform.parent = null;
                _currentProjectileLoaded.SetEnemy((_turret.CurrentEnemyTarget));
            }

            _nextAttackTime = Time.time + DelayPerShot;
        }

        
    }

    protected virtual void LoadProjecttile()
    {
        GameObject newInstance = _pooler.GetInstanceFromPool();
        newInstance.transform.position = projecttileSpawnPosition.position;
        newInstance.transform.SetParent(projecttileSpawnPosition);

        _currentProjectileLoaded = newInstance.GetComponent<Projectile>();
        _currentProjectileLoaded.TurretOwner = this;
        _currentProjectileLoaded.ResetProjectile();
        _currentProjectileLoaded.Damage = Damage;
        
        newInstance.SetActive(true);
        

    }

    private bool IsTurrentEmpty()
    {
        return _currentProjectileLoaded == null;
    }
    public void ResetTurretProjectile()
    {
        _currentProjectileLoaded = null;
    }


}
