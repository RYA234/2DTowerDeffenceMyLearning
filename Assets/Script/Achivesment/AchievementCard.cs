using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCard : MonoBehaviour
{
   [SerializeField] private Image achievementImage;
   [SerializeField] private TextMeshProUGUI title;
   [SerializeField] private TextMeshProUGUI progress;
   [SerializeField] private TextMeshProUGUI reward;
   [SerializeField] private Button rewardButton;
   

   public Achievement AchievementLoaded { get; set; }
   
   public void SetupAchievement(Achievement achievement)
   {
       AchievementLoaded = achievement;
       achievementImage.sprite = achievement.Sprite;
       title.text = achievement.Title;
       progress.text = achievement.GetProgress();
       reward.text = achievement.GoldReward.ToString();
       
   }

   public void GetReward()
   {
       if (AchievementLoaded.IsUnlocked)
       {
           CurrencySystem.Instance.AddCoins(AchievementLoaded.GoldReward);
           rewardButton.gameObject.SetActive(false);
       }
   }

   private void UpdateProgress(Achievement achievementWithProgress)
   {
       if (AchievementLoaded == achievementWithProgress)
       {
           progress.text = achievementWithProgress.GetProgress();
       }
   }

   private void AchievementUnlocked(Achievement achievement)
   {
       if (AchievementLoaded == achievement)
       {
           rewardButton.interactable = true;
       }
   }

   private void OnEnable()
   {
       AchievementManager.OnProgressUpdated += UpdateProgress;
       AchievementManager.OnAchievementUnlocked += AchievementUnlocked;
       
   }
   
    private void OnDisable()
    {
        AchievementManager.OnProgressUpdated -= UpdateProgress;
        AchievementManager.OnAchievementUnlocked -= AchievementUnlocked;
    }
}
