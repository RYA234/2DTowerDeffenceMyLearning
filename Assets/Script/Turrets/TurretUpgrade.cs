using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgrade : MonoBehaviour
{
    
    [SerializeField] private int upgradeInitialCost;
    [SerializeField] private int upgradeCostIncremental;
    [SerializeField] private float damageIncremental;
    [SerializeField] private float delayReduce;
    private TurretProjectTile _turretProjectTile;
    private void Start()
    {
        _turretProjectTile = GetComponent<TurretProjectTile>();
    }

    // Update is called once per frame
   private void Update()
   {
       if(Input.GetKeyDown(KeyCode.D))
       {
           UpgradeTurret();
       }
   }

   private void UpgradeTurret()
   {
       _turretProjectTile.Damage += damageIncremental;
       _turretProjectTile.DelayPerShot -= delayReduce;
   }
}
