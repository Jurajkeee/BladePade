using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.UI;

public class GUINames : MonoBehaviour
{

    public Lang langClass;
    public string currentLang;

    public Text skinsT, weaponsT, buyT, buyT2 , goldT, crystalsT, languageT,
                graphicsT, cancelT, confirmT, musicT, 
                soundsT,settingsT;

    private void Start()
    {
        langClass = new Lang(Path.Combine(Application.dataPath, "/Users/macbookproretina/Downloads/Disk F/BladePade/BladePade/Assets/Scenes/MultiLanguage/LanguageDictionary.xml"), currentLang); 

        skinsT.GetComponent<Text>().text = langClass.GetString("skins");
        weaponsT.GetComponent<Text>().text = langClass.GetString("weapons");
        buyT.GetComponent<Text>().text = langClass.GetString("buy");
        goldT.GetComponent<Text>().text = langClass.GetString("gold");
        crystalsT.GetComponent<Text>().text = langClass.GetString("crystals");
        buyT2.GetComponent<Text>().text=langClass.GetString("buy");
        languageT.GetComponent<Text>().text = langClass.GetString("language");
        graphicsT.GetComponent<Text>().text = langClass.GetString("graphics");
        cancelT.GetComponent<Text>().text = langClass.GetString("cancel");
        confirmT.GetComponent<Text>().text = langClass.GetString("confirm");
        musicT.GetComponent<Text>().text = langClass.GetString("music");
        soundsT.GetComponent<Text>().text = langClass.GetString("sounds");
        settingsT.GetComponent<Text>().text = langClass.GetString("settings");


    }

}
