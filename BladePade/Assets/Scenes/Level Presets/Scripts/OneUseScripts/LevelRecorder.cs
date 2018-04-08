using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SENDING DATA TO DATABASE, NEEDED BECAUSE WHEN UNFINISHED LEAVE NOT TO SEND DATA TO DB
public class LevelRecorder : MonoBehaviour {
    [Space(4)] [TextArea] public string description;[Space(4)]
    [Header("Stats")][Space(2)] 
    public int starsCollected;
    public float finishTime;
    public int usedBlades;
    [Space(10)]
    public Level levelstats;
    public GUIDirector director;
    public PlayerDB playerDB;

    public Text timerT;
    
    float time;

    [Space(10)]
    [Header("Currency")]
    public bool useTimeMultiplier;
    public bool useBladeBonus;
    public int coins;

    public void Finished(){
        if (levelstats.stars < starsCollected) levelstats.stars = starsCollected;
        finishTime = time;
        if (levelstats.bestTime > finishTime || levelstats.bestTime == 0) { levelstats.bestTime = finishTime; }
        levelstats.isCompleted = true;
        coins = MoneyGiver.CalculateCurrency(this, useTimeMultiplier, useBladeBonus);
        playerDB.gold += coins;
        levelstats.multiplier= 1;
       
        director.FinishWindow();

    }
    private void Update()
    {
        time += Time.deltaTime;
        timerT.text = ConvertToNormalTimer(time);             
    }

    public string ConvertToNormalTimer(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);
        return minutes + ":" + seconds;
    }

}
