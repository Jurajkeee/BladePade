using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

    [XmlRoot("DataCollection")]
    public class DataCollection
    {
    [XmlArray("Data")]
    [XmlArrayItem("Data")]
    public info_config_scriptable_object info_Config = new info_config_scriptable_object();
    }
    
    public class InfoManager : MonoBehaviour {
    
    public info_config_scriptable_object info_Config;
    public XmlDocument xml;
    private string path = "Assets/GameData/config/singletone/info_config/save.xml";
    string _data;
    public int gold, diamonds,current_skin,current_weapon;
    [Header("~~~~~~~~~~~~~~~~~~~~~~Settings~~~~~~~~~~~~~~~~~~~~~~~~~~~")]
    public bool set_up_for_menu;
    private GUINames guinames;

	private void Start () {
        info_Config = Resources.Load<info_config_scriptable_object>("InfoConfig");
        LoadXML();
        LoadData();

        current_skin = info_Config.currentSkin;
        current_weapon = info_Config.currentWeapon;

        SkinsLoader skinsloader = this.gameObject.GetComponent<SkinsLoader>();
        if (skinsloader != null && skinsloader.load_skins_on_start)
        {
            skinsloader.skin = current_skin;            
            skinsloader.LoadSkin();          
            skinsloader.weapon = current_weapon;           
            skinsloader.hand_sword.sprite = skinsloader.GetWeapon();
        }
        if(set_up_for_menu)guinames = GameObject.Find("EventSystem").GetComponent<GUINames>();
    }
    private void Update()
    {
        gold = info_Config.gold;
        diamonds = info_Config.diamonds;
        UpdateBalanceAndLanguage(set_up_for_menu);
    }
    public void UpdateBalanceAndLanguage(bool boolean)
    {
        if (boolean)guinames.UpdateBalance();
        
    }

    private void OnDestroy()
    {
        string json = JsonUtility.ToJson(info_Config, true);
        _data = json;
        Save();
        print(json);
    }
    private void OnApplicationFocus(bool focus)
    {
        if(focus==false){
            string json = JsonUtility.ToJson(info_Config, true);
            _data = json;
            Save();
            print(json);
        }
    }
    private void LoadData(){
        JsonUtility.FromJsonOverwrite(_data, info_Config);
        Debug.Log("Data Loaded");
    }
    void LoadXML() 
   {
        if (File.Exists(Application.persistentDataPath + "/save.xml")){
            StreamReader r = File.OpenText(Application.persistentDataPath + "/save.xml");

            string _info = r.ReadToEnd();
            r.Close();
            _data = _info;
            Debug.Log("File Read");
        }
        else {
            File.Create(Application.persistentDataPath + "/save.xml");
            Debug.Log("SaveCreated");
        }
   } 
    void Save(){
        StreamWriter writer;
        FileInfo t = new FileInfo(Application.persistentDataPath + "/save.xml");
        t.Delete(); 
         writer = t.CreateText(); 
        writer.Write(_data); 
         writer.Close(); 
        Debug.Log("File written."); 
    }

}
