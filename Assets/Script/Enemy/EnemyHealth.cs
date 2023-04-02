using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static Action OnEnemyKilled;
    
    // Start is called before the first frame update
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;

    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    public float CurrentHealth { get; set; }
    private Image _healthBar;
    void Start()
    {
        CreateHealthBar();
        CurrentHealth = initialHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DealDamage(5f);
        }

        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, CurrentHealth / maxHealth, Time.deltaTime * 10f);
    }

    private void CreateHealthBar()
    {
        GameObject newBar = Instantiate(healthBarPrefab,barPosition.position,Quaternion.identity);
        newBar.transform.SetParent(transform);
        
        EnemyHealthContainer container = newBar.GetComponent<EnemyHealthContainer>();
        _healthBar = container.FillAmountImage;
    }

    public void DealDamage(float damageReceived)
    {
        CurrentHealth -= damageReceived;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = initialHealth;
        _healthBar.fillAmount = 1f;
    }
    private void Die()
    {
        OnEnemyKilled?.Invoke();
        CurrentHealth = initialHealth;
        _healthBar.fillAmount = 1f;
        ObjectPooler.ReturnToPool(gameObject);
    }
    
    
}
