using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] private GameObject turretShopPanel;

    [SerializeField] private GameObject nodeUIPanel;
    [SerializeField] private TextMeshProUGUI upgradeText;
    [SerializeField] private TextMeshProUGUI sellText;
    public TurretUpgrade TurretUpgrade { get; set; }
    private Node _currentNodeSelected;

    // 追加箇所
    public void CloseTurretShopPanel()
    {
        turretShopPanel.SetActive(false);
    }

    public void UpgradeTurret()
    {
        _currentNodeSelected.Turrets.TurretUpgrade.UpgradeTurret();
        UpdateUpgradeText();
    }
    private void ShowNodeUI()
    { 
        nodeUIPanel.SetActive(true);
       // UpdateUpgradeText();
    }

    private void UpdateUpgradeText()
    {
        upgradeText.text = _currentNodeSelected.Turrets.TurretUpgrade.UpgradeCost.ToString();
    }
    private void NodeSelected(Node nodeSelected)
    {
        _currentNodeSelected = nodeSelected;
        if (_currentNodeSelected.IsEmpty())
        {
            turretShopPanel.SetActive(true);
        }
        else
        {
            ShowNodeUI();
        }
    }
    private void OnEnable()
    {
        Node.OnNodeSelected += NodeSelected;
    }

    private void OnDisable()
    {
        Node.OnNodeSelected -= NodeSelected;
    }
}
