using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[CreateAssetMenu(fileName ="InfoConfig",menuName ="Singletones/InfoConfig",order = 3)]
public class info_config_scriptable_object : ScriptableObject {
    [XmlAttribute("name")]
    public int gold;
    public int diamonds;
    public int currentLevel;
    public List<int> mySkins = new List<int>();
    public List<int> myWeapons = new List<int>();
    public int currentSkin;
    public int currentWeapon;
    [Space(20)]
    public int music;
    public int sounds;
    public string language;
    public int graphics;
    [Space(10)]
    public List<int> LevelsStarsHashtable = new List<int>(20);
    public List<float> BestTimeHashtable = new List<float>(20);
     
    public void AddLevel(Level level)
    {
        Debug.Log("1.1");
        LevelsStarsHashtable[level.levelID] =level.stars;
        BestTimeHashtable[level.levelID]= level.bestTime;
        Debug.Log(level.levelID+"Level added");
    }

}
