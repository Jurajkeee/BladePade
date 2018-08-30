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
                soundsT,settingsT,graphicalIndicator,goldBalanceT,diamondsBalanceT
                ,templeT,pyramidsT,junglesT,townT,caveT;

    public UIDirector uiDirector;
    public PlayerDB playerDb;

    public SettingsSO settingsPref;

    public InfoManager singletone;

    public Image debugImg;



    private void Start()
    {
        
        GetNames();

        graphicalIndicator = graphicalIndicator.GetComponent<Text>();

        uiDirector=uiDirector.GetComponent<UIDirector>();

        UpdateBalance();
        UpdateLanguage();

    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (File.Exists(Application.streamingAssetsPath + "/LanguageDictionary.xml"))
            {
                debugImg.color = new Color(0, 0, 0);
            }
        }
        else if (Application.platform == RuntimePlatform.OSXEditor)
        {
            if (File.Exists(Application.streamingAssetsPath + "/LanguageDictionary.xml"))
            {
                debugImg.color = new Color(0, 173, 0);
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (File.Exists(Application.streamingAssetsPath + "/LanguageDictionary.xml"))
            {
                debugImg.color = new Color(0, 0, 175);
            }

        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (File.Exists(Application.streamingAssetsPath+ "/LanguageDictionary.xml"))
            {
                debugImg.color = new Color(123, 123, 0);
            }

        }

    }
    public void UpdateLanguage()
    {
        GetNames();
        UpdateGraphicSlider();
    }
    public void UpdateBalance(){
        goldBalanceT.text = singletone.gold.ToString();
        diamondsBalanceT.text = singletone.diamonds.ToString();
    }
    public void UpdateGraphicSlider(){
        switch (uiDirector.graphicsSlider.value.ToString())
        {            
            case "0":  graphicalIndicator.text = langClass.GetString("low"); break; //GUINames - access to dictionary
            case "1":  graphicalIndicator.text = langClass.GetString("mid"); break;
            case "2":  graphicalIndicator.text = langClass.GetString("high"); break;
        }

    }

    public void GetNames(){

        currentLang = singletone.info_Config.language;

        langClass = new Lang(Application.streamingAssetsPath + "/LanguageDictionary.xml", currentLang); //macbook
        
        //langClass = new Lang(Path.Combine(Application.dataPath, "C:/Users/po4ta/Desktop/BladePade/BladePade/Assets/Scenes/MultiLanguage/LanguageDictionary.xml"), currentLang); //PC
        skinsT.text = langClass.GetString("skins");
        weaponsT.text = langClass.GetString("weapons");
        buyT.text = langClass.GetString("buy");
        goldT.text = langClass.GetString("gold");
        crystalsT.text = langClass.GetString("crystals");
        buyT2.text = langClass.GetString("buy");
        languageT.text = langClass.GetString("language");
        graphicsT.text = langClass.GetString("graphics");
        cancelT.text = langClass.GetString("cancel");
        confirmT.text = langClass.GetString("confirm");
        musicT.text = langClass.GetString("music");
        soundsT.text = langClass.GetString("sounds");
        settingsT.text = langClass.GetString("settings");
        townT.text = langClass.GetString("town");
        pyramidsT.text = langClass.GetString("pyramids");
        junglesT.text = langClass.GetString("jungles");
        templeT.text = langClass.GetString("temple");
        caveT.text = langClass.GetString("caves");


    }

}
