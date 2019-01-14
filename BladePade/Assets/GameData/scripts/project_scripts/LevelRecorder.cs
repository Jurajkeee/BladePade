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
    public info_config_scriptable_object info_Config;
    
    float time;

    [Space(10)]
    [Header("Currency")]
    public bool useTimeMultiplier;
    public bool useBladeBonus;
    public int coins;
    public int diamonds;

    public void Finished(){
        info_Config = Resources.Load<info_config_scriptable_object>("InfoConfig");
        if (info_Config.currentLevel == levelstats.levelID) info_Config.currentLevel++;

        MoneyGiver.CalculateAwards(this);

        if (levelstats.stars < starsCollected) levelstats.stars = starsCollected;
        finishTime = time;
        if (levelstats.bestTime > finishTime || levelstats.bestTime == 0) { levelstats.bestTime = finishTime; }

        info_Config.gold += coins;
        info_Config.diamonds += diamonds;
        levelstats.multiplier= 1;

        levelstats.isCompleted = true;

        info_Config.AddLevel(levelstats);
       
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
