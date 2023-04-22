using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    [SerializeField] private AchievementCard _achievementCardPrefab;
    [SerializeField] private Transform achievementPanelContainer;
    [SerializeField] private Achievement[] achievements;

    private void Start()
    {
        LoadAchievements();
    }

    private void LoadAchievements()
    {
        for (int i = 0; i < achievements.Length; i++)
        {
            AchievementCard card = Instantiate(_achievementCardPrefab, achievementPanelContainer);
            card.SetupAchievement(achievements[i]);
        }
    }
    
}
