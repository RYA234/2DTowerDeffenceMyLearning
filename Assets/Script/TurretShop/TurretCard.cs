using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretCard : MonoBehaviour
{
    [SerializeField] private Image turretImage;
    [SerializeField] private TextMeshProUGUI turretCost;

    public void SetupTurretButton(TurretSetting turretSetting)
    {
        turretImage.sprite = turretSetting.TurretShopSprite;
        turretCost.text = turretSetting.TurretShopCost.ToString();
        
    }
}
