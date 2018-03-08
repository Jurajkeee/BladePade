using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonScript : MonoBehaviour {
    public Level level;
    public Level previousLevel;  
    [Space(10)]
    public Image[] stars = new Image[2];
    public Text bestTime;
    [Space(10)]
    public GameObject directorGO;
    private UIDirector director;

	void Start () {
        director = directorGO.GetComponent<UIDirector>();
        UpdateStats();
	}
    public void UpdateStats()
    {
        for(int i=0; i<level.stars; i++)
        {
            stars[i].enabled = true;
        }
        bestTime.text = level.bestTime;
        if (previousLevel.isCompleted == true) { level.isReady = true; director.UpdatePlayButton(true); }  else { level.isReady = false; director.UpdatePlayButton(false); }
    }
    public void SendIDToDirector()
    {
        director.ToLevelID = level.levelID;
        director.UpdatePlayButton(true);
    }

}
