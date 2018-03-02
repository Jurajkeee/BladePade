using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonScript : MonoBehaviour {
    public Level level;   
    public Image[] stars = new Image[2];
    public Text bestTime;
   

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
    }
    public void SendIDToDirector()
    {
        Debug.Log(director.ToLevelID);
        //director.ToLevelID = level.levelID;
    }

}
