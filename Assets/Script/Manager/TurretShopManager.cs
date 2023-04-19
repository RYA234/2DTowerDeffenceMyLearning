using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShopManager : MonoBehaviour
{
    [SerializeField] private GameObject turretCardPrefab;
    [SerializeField] private Transform turretPanelContainer;

    [Header("Turret Setting")] [SerializeField]
    private TurretSetting[] turrets;

    private void Start()
    {
        for (int i = 0; i < turrets.Length; i++)
        {
            CreateTurretCard(turrets[i]);
        }
    }
    
    private void CreateTurretCard(TurretSetting turretSetting)
    {
        GameObject newInstance = Instantiate(turretCardPrefab, turretPanelContainer.position, Quaternion.identity);
        newInstance.transform.SetParent(turretPanelContainer);
        newInstance.transform.localScale = Vector3.one;

        TurretCard cardButton = newInstance.GetComponent<TurretCard>();
        cardButton.SetupTurretButton(turretSetting);
        
    }

}
