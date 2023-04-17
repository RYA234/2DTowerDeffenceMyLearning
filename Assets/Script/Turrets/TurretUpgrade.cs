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
    
    public int UpgradeCost { get; set;}
    private void Start()
    {
        _turretProjectTile = GetComponent<TurretProjectTile>();
        UpgradeCost = upgradeInitialCost;
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
       if (CurrencySystem.Instance.TotalCoins >= UpgradeCost)
       {
           _turretProjectTile.Damage += damageIncremental;
           _turretProjectTile.DelayPerShot -= delayReduce;
           UpdateUpgrade();
       }
   }

   private void UpdateUpgrade()
   {
       CurrencySystem.Instance.RemoveCoins(UpgradeCost);
       UpgradeCost += upgradeCostIncremental;
   }
}
