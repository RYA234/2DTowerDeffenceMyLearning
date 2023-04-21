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
    public int Level { get; set; }
    [Header("Sell")] [SerializeField] private float sellPert;
    public float SellPerc { get; set; }
    
    
    public int UpgradeCost { get; set;}
    private void Start()
    {
        _turretProjectTile = GetComponent<TurretProjectTile>();
        UpgradeCost = upgradeInitialCost;
        SellPerc = sellPert;
        Level = 1;
    }


   public void UpgradeTurret()
   {
       if (CurrencySystem.Instance.TotalCoins >= UpgradeCost)
       {
           _turretProjectTile.Damage += damageIncremental;
           _turretProjectTile.DelayPerShot -= delayReduce;
           UpdateUpgrade();
           Level++;
       }
   }

   public int GetSellValue()
   {
       int sellValue = Mathf.RoundToInt(UpgradeCost * SellPerc);
       return sellValue;
   }

   private void UpdateUpgrade()
   {
       CurrencySystem.Instance.RemoveCoins(UpgradeCost);
       UpgradeCost += upgradeCostIncremental;
   }
}
