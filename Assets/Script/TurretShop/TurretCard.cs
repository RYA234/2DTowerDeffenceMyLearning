using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretCard : MonoBehaviour
{
    public static Action<TurretSetting> OnPlaceTurret;
    [SerializeField] private Image turretImage;
    [SerializeField] private TextMeshProUGUI turretCost;

    public TurretSetting TurretLoaded { get; set; }
    
    public void SetupTurretButton(TurretSetting turretSetting)
    {
        TurretLoaded = turretSetting;
        turretImage.sprite = turretSetting.TurretShopSprite;
        turretCost.text = turretSetting.TurretShopCost.ToString();
        
    }
    
}
