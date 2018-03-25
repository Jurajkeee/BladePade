using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SENDING DATA TO DATABASE, NEEDED BECAUSE WHEN UNFINISHED LEAVE NOT TO SEND DATA TO DB
public class LevelRecorder : MonoBehaviour {
    
    public int starsCollected;
    public TimeSpan finishTime;
    public Level levelstats;

    public Text timerT;
    float time;
    private void Start()
    {
        levelstats.ShowBestTime();
    }
    public void Finished(){
        if (levelstats.stars < starsCollected) levelstats.stars = starsCollected;

        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);
        finishTime = new TimeSpan(0,(Int32) minutes, (Int32)seconds);
        if (levelstats.bestTime < finishTime || levelstats.bestTime == TimeSpan.MinValue) levelstats.bestTime = finishTime;

        levelstats.isCompleted = true;
        Debug.Log("Finished");
        levelstats.ShowBestTime();
    }
    private void Update()
    {
        time += Time.deltaTime;
        timerT.text = time.ToString();              
    }



}
