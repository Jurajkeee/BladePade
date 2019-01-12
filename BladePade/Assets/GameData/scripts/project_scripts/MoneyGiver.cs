using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGiver
{
    private static int earnedGold;
    private static int earnedDiamonds;

    public static void CalculateAwards(LevelRecorder levelRecorder)
    {
        earnedGold = 0;
        earnedDiamonds = 0;

        CalculateSwords(levelRecorder);
        CalculateStars(levelRecorder);
        CalculateIfFirstTime(levelRecorder);
        CalculateTime(levelRecorder);

        Debug.Log("AWARD/ " + "gold: " + earnedGold + " diamonds: " + earnedDiamonds);

        levelRecorder.coins += earnedGold;
        levelRecorder.diamonds += earnedDiamonds; 
    }


    private static void CalculateSwords(LevelRecorder levelRecords)
    {
        if (levelRecords.usedBlades <= levelRecords.levelstats.swordsForGoldAchieve)
        {
            earnedGold += levelRecords.levelstats.RewardForCompletingWithOtimalUsedSwords;
            earnedDiamonds += levelRecords.levelstats.diamondsForAchievmentCompleted;
            Debug.Log("Awards/ Swords Achievment " + levelRecords.usedBlades);
        }
    }
    private static void CalculateStars(LevelRecorder levelRecords)
    {
        if (levelRecords.starsCollected > levelRecords.levelstats.stars)
        {
            earnedGold += levelRecords.starsCollected * levelRecords.levelstats.starValue;
            earnedDiamonds += levelRecords.starsCollected * levelRecords.levelstats.diamondsForAchievmentCompleted;
            Debug.Log("Awards/ Stars " + levelRecords.starsCollected);
        }
    }
    private static void CalculateTime(LevelRecorder levelRecords)
    {
        if (levelRecords.finishTime < levelRecords.levelstats.timeForMultiplier)
        {
            earnedGold *= levelRecords.levelstats.multiplier;
            earnedDiamonds *= levelRecords.levelstats.multiplier;
            Debug.Log("Awards/ In Time");
        }
    }
    private static  void CalculateIfFirstTime(LevelRecorder levelRecords)
    {
        if (!levelRecords.levelstats.isCompleted)
        {
            earnedGold += levelRecords.levelstats.bonusForFirstTime;
            earnedDiamonds += levelRecords.levelstats.diamondsForAchievmentCompleted * 5;
            Debug.Log("Awards/ First Time");
        }
        earnedGold += levelRecords.levelstats.bonusForComplete;
    }
}
