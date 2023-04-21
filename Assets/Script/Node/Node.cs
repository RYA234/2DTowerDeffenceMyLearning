using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static Action<Node> OnNodeSelected;
    public static Action OnTurretSold;
    [SerializeField] private GameObject attackRangeSprite;
    
    public Turrets Turrets { get; set; }
    
    private float _rangeSize;
    private Vector3 _rangeOriginalSize;

    private void Start()
    {
        _rangeSize = attackRangeSprite.GetComponent<SpriteRenderer>().bounds.size.y;
        _rangeOriginalSize = attackRangeSprite.transform.localScale;
    }

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
        if (!IsEmpty())
        {
            ShowTurretInfo();
        }
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

    private void ShowTurretInfo()
    {
        attackRangeSprite.SetActive(true);
        attackRangeSprite.transform.localScale = _rangeOriginalSize * Turrets.AttackRange / (_rangeSize / 2);
    }
}
