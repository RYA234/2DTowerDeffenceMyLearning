using System;
using UnityEngine;


public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int lives = 10;

    public int TotalLives { get; set; }
    private void Start()
    {
        TotalLives = lives;
    }

    private void ReduceLives(Enemy enemy)
    {
        TotalLives--;
        if (TotalLives <= 0)
        {
            TotalLives = 0;
        }
    }
    private void OnEnable()
    {
        Enemy.OnEndReached += ReduceLives;  
    }

    private void OnDisable()
    {
        Enemy.OnEndReached -= ReduceLives;  
    }
}
