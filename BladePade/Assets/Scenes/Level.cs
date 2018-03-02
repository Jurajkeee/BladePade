using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public new string name;
    public string description;
    public int levelID;

    
    public string bestTime;   
    public int stars;
    public string NewBestTime(string bestTime)
    {
        return this.bestTime = bestTime;
    }
    public int NewStars(int stars)
    {
        return this.stars = stars;
    }

}
