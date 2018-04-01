using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGiver
{
    public static int CalculateCurrency(LevelRecorder levelRecords, bool useTimeMultiplier, bool useSwordsMultiplier)
    {
        int currency;
        if (levelRecords.levelstats.stars < levelRecords.starsCollected)
        { currency = (levelRecords.starsCollected * levelRecords.levelstats.starValue); }
        else
        { currency = levelRecords.levelstats.bonusForComplete;}
        
        if (useSwordsMultiplier)
        {           
           currency+= (levelRecords.levelstats.swordsForGoldAchieve - levelRecords.usedBlades)*levelRecords.levelstats.bladeValue*levelRecords.levelstats.multiplier;
        }
        if (useTimeMultiplier)
        {
            if (levelRecords.finishTime < levelRecords.levelstats.timeForMultiplier) currency *= 2;
        }
        return currency;
    }
}
