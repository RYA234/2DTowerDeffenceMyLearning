using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectTile : MonoBehaviour
{

    [SerializeField] private Transform projecttileSpawnPosition;
    private ObjectPooler _pooler;
    private Turrets _turret;
    private Projectile _currentProjectileLoaded;
    

    private void Start()
    {
        _pooler = GetComponent<ObjectPooler>();
        _turret = GetComponent<Turrets>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LoadProjecttile();
        }


    }

    private void LoadProjecttile()
    {
        GameObject newInstance = _pooler.GetInstanceFromPool();
        newInstance.transform.position = projecttileSpawnPosition.position;
        newInstance.transform.SetParent(projecttileSpawnPosition);
        newInstance.SetActive(true);
        

    }
}
