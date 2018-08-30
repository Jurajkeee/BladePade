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
    public info_config_scriptable_object info_Config;

	void Start () {
        info_Config = Resources.Load<info_config_scriptable_object>("InfoConfig");
        director = directorGO.GetComponent<UIDirector>();
        UpdateStats();
	}
    public void UpdateStats()
    {
        for(int i=0; i<level.stars; i++)
        {
            stars[i].enabled = true;
        }
        bestTime.text = level.bestTime.ToString();
        if (info_Config.currentLevel>=level.levelID) { level.isReady = true; director.UpdatePlayButton(true); }  else { level.isReady = false; director.UpdatePlayButton(false); }
    }
    public void SendIDToDirector()
    {
        director.ToLevelID = level.levelID;
        director.UpdatePlayButton(true);
    }

}
