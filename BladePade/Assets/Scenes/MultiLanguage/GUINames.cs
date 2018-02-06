using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.UI;

public class GUINames : MonoBehaviour
{

    private Lang langClass;
    public string currentLang;

    public Text skinsT, weaponsT, buyT, buyT2 , goldT, crystalsT;

    private void Start()
    {
        langClass = new Lang(Path.Combine(Application.dataPath, "/Users/macbookproretina/Downloads/Disk F/BladePade/BladePade/Assets/Scenes/MultiLanguage/LanguageDictionary.xml"), currentLang); 

        skinsT.GetComponent<Text>().text = langClass.GetString("skins");
        weaponsT.GetComponent<Text>().text = langClass.GetString("weapons");
        buyT.GetComponent<Text>().text = langClass.GetString("buy");
        goldT.GetComponent<Text>().text = langClass.GetString("gold");
        crystalsT.GetComponent<Text>().text = langClass.GetString("crystals");
        buyT2.GetComponent<Text>().text=langClass.GetString("buy");

    }

}
