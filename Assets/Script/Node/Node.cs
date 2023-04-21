using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static Action<Node> OnNodeSelected;
    public static Action OnTurretSold;
    
    public Turrets Turrets { get; set; }

    public void SetTurret(Turrets turrets)
    {
        Turrets = turrets;
    }

    public bool IsEmpty()
    {
        return Turrets == null;
    }

    public void SelectTurret()
    {
        OnNodeSelected?.Invoke(this);
    }

    public void SellTurret()
    {
        if (!IsEmpty())
        {
            CurrencySystem.Instance.AddCoins(Turrets.TurretUpgrade.UpgradeCost);
            Destroy(Turrets.gameObject);
            Turrets = null;
            OnTurretSold?.Invoke();
        }
    }
}
