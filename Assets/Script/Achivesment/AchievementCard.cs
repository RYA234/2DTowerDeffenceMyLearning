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

   public Achievement AchievementLoaded { get; set; }
   
   public void SetupAchievement(Achievement achievement)
   {
       AchievementLoaded = achievement;
       achievementImage.sprite = achievement.Sprite;
       title.text = achievement.Title;
       progress.text = achievement.GetProgress();
       reward.text = achievement.GoldReward.ToString();
       
   }

   private void UpdateProgress(Achievement achievementWithProgress)
   {
       if (AchievementLoaded == achievementWithProgress)
       {
           progress.text = achievementWithProgress.GetProgress();
       }
   }

   private void OnEnable()
   {
       AchievementManager.OnProgressUpdated += UpdateProgress;
   }
   
    private void OnDisable()
    {
        AchievementManager.OnProgressUpdated -= UpdateProgress;
    }
}
