﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[CreateAssetMenu(fileName ="New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    [Header("Description")]
    public new string name;
    public string description;
    public int levelID;

    [Header("Accessibility")]
    public bool isCompleted;
    public bool isReady;

    [Header("Scores")]

    public TimeSpan bestTime;
   
    public int stars;

    public void LoadScene(){
        SceneManager.LoadScene(levelID);
    }
    public void ShowBestTime(){
        Debug.Log(bestTime);
    }

}
