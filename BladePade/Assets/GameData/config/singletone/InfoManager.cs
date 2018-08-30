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
    public int gold, diamonds;

	private void Start () {
        info_Config = Resources.Load<info_config_scriptable_object>("InfoConfig");
        LoadXML();
        LoadData();
	}
    private void Update()
    {
        gold = info_Config.gold;
        diamonds = info_Config.diamonds;
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
