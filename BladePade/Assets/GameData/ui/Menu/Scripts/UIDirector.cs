using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDirector : MonoBehaviour
{

    #region "Window Director Vars"
    //Main Menu
    [Header("Main Menu")]
    
    public Canvas shopMenu, donationShopMenu, levelMenu, settingsMenu;

    #region "Better Close Vars"
    //Savings Methods

    public delegate void LastMethod();

    LastMethod lastMethod;
     #endregion
    #endregion
    #region "Map Window Vars"
    //In Level Menu
    
    [Header("Map Menu")]
    public Image chooseLevels;
    public Image chooseChapters;
    public GameObject buttonToChapter1;
    public GameObject levelsListC1, levelsListMenu;

    #region "Levels"
    [Header("Levels Menu")]
    public GameObject[] level;
    public int ToLevelID = 12;
    public Image playButton;
    #endregion

    #endregion
    #region "Settings Window Vars"

    //Cancel and Confirm in Setting menu

    [Header("Settings Menu")]
    public info_config_scriptable_object info_Config;
    [Space(20)]
    public bool sounds;
    public bool music;//DElete when music
    private int tempSounds, tempMusic;
    public int graphicQuality;//delete when qual
    private int tempGraphicsQual;
    private string tempLang;

    public string OnOffMusic, OnOffSounds;
    public int musicValueTemp, soundValueTemp;

    // Setting Buttons
    public Slider soundsButton, musicButton;
    public Text soundsIndicator, musicIndicator;
    public Slider graphicsSlider;
    public Image settingsButton;

     #region "Language List Vars"

    [Header("Languages List")]
    public GameObject englishActive;
    public GameObject russianActive, germanActive, chineseActive, activeLang;
    public Image list, hiddenList;
    public Text currentLangOnList;

    [SerializeField]
    private GUINames guiNames;
    #endregion
    #endregion

    void Start()
    {
        #region "UIDirector"
        guiNames = guiNames.GetComponent<GUINames>();
        guiNames.UpdateBalance();
      
        shopMenu = shopMenu.GetComponent<Canvas>();
        donationShopMenu = donationShopMenu.GetComponent<Canvas>();
        levelMenu = levelMenu.GetComponent<Canvas>();
        settingsMenu = settingsMenu.GetComponent<Canvas>();

        settingsMenu.enabled = false;
        shopMenu.enabled = false;
        donationShopMenu.enabled = false;
        levelMenu.enabled = false;
        #endregion
        #region "Map Window"
        //In Level Menu
        chooseChapters = chooseChapters.GetComponent<Image>();
        chooseLevels = chooseLevels.GetComponent<Image>();

        chooseLevels.enabled = false;
        chooseChapters.enabled = false;

        
        buttonToChapter1.SetActive(false);


        #region "LevelsWindow"
        UpdateLevelsStats();
        #endregion

        #endregion
        #region "Settings Window"
        // Settings 
        info_Config = Resources.Load<info_config_scriptable_object>("InfoConfig");
        soundsButton = soundsButton.GetComponent<Slider>();
        soundsIndicator = soundsIndicator.GetComponent<Text>();
        musicButton = musicButton.GetComponent<Slider>();
        musicIndicator = musicIndicator.GetComponent<Text>();
        graphicsSlider = graphicsSlider.GetComponent<Slider>();

        settingsButton = settingsButton.GetComponent<Image>();

        #region "Languages List"
        //Languages

        list = list.GetComponent<Image>();
        hiddenList = hiddenList.GetComponent<Image>();



        list.enabled = false;

        englishActive.SetActive(false);
        russianActive.SetActive(false);
        germanActive.SetActive(false);
        chineseActive.SetActive(false);
        #endregion
        #endregion

        //settingsPreferences.musicButtonPosition = musicButton.transform.position;
        //settingsPreferences.soundsButtonPosition = soundsButton.transform.position;

    }

    //Windows Director
    public void ToShop()
    {
        settingsButton.enabled = !settingsButton.enabled;
        
        shopMenu.enabled = !shopMenu.enabled;
        lastMethod = ToShop;

    }
    public void ToDonationShop()
    {
        settingsButton.enabled = !settingsButton.enabled;
       
        donationShopMenu.enabled = !donationShopMenu.enabled;
        lastMethod = ToDonationShop;

    }
    public void Close()
    {
        lastMethod();
        if(lastMethod == ChooseLevels) { lastMethod = ToLevelMenu; }
            else 
        if (lastMethod == LevelsList) { lastMethod = ChooseLevels; }
            else lastMethod = null;       
    }
    public void Settings()
    {
        settingsButton.enabled = !settingsButton.enabled;
        currentLangOnList.text = guiNames.currentLang;
        settingsMenu.enabled = !settingsMenu.enabled;

        lastMethod = Settings;

        musicValueTemp = info_Config.music;
        soundValueTemp = info_Config.sounds;

        musicButton.value = info_Config.music;
        soundsButton.value = info_Config.sounds;

        tempGraphicsQual = info_Config.graphics; //Save begin value
        tempLang = guiNames.currentLang;

        graphicsSlider.value = info_Config.graphics;

        tempSounds = info_Config.sounds;
        //soundsButton.transform.position = settingsPreferences.soundsButtonPosition;
        Sounds();
        Music();

    }

    //Map
    public void ToLevelMenu()
    {
        settingsButton.enabled = !settingsButton.enabled;     
        levelMenu.enabled = !levelMenu.enabled;
        buttonToChapter1.SetActive(!buttonToChapter1.activeSelf);

        levelsListC1.SetActive(false);
        chooseLevels.enabled = false;
        levelsListMenu.SetActive(false);



        chooseChapters.enabled = !chooseChapters.enabled;
        lastMethod = ToLevelMenu;

    }
    public void ChooseLevels() //Chapter 1 Need to optimize for all chapters
    {
        chooseChapters.enabled = !chooseChapters.enabled;
        chooseLevels.enabled = !chooseLevels.enabled;
        buttonToChapter1.SetActive(!buttonToChapter1.activeSelf);
        lastMethod = ChooseLevels;
        levelsListC1.SetActive(!levelsListC1.activeSelf);
        levelsListMenu.SetActive(false);
    }
    public void LevelsList() //Levels Menu
    {
        lastMethod = LevelsList;
        levelsListMenu.SetActive(!levelsListMenu.activeSelf);
        ToLevelID = 20;
        UpdateLevelsStats();
    }
    public void PlayButton()
    {
        level[ToLevelID-1].GetComponent<LevelButtonScript>().level.LoadScene();
    }
    public void UpdatePlayButton(bool isReady)
    {
        if (!isReady) { playButton.color = new Color(1, 0.5f, 0.5f); playButton.GetComponent<Button>().enabled = false; }
        else { playButton.color = Color.white; playButton.GetComponent<Button>().enabled = true; }
    }
    public void UpdateLevelsStats()
    {
        UpdatePlayButton(false);
        for (int i = 0; i < level.Length; i++)
        {
            level[i].GetComponent<LevelButtonScript>().UpdateStats();
            for (int j = 0; j < 3; j++)
            {
                level[i].GetComponent<LevelButtonScript>().stars[j].enabled = false;
                if (!level[i].GetComponent<LevelButtonScript>().level.isReady)
                {
                  level[i].GetComponent<Button>().enabled = false;
                  level[i].GetComponent<Image>().color = new Color(0.85f, 0.85f, 0.85f); }
                else
                {
                  level[i].GetComponent<Button>().enabled = true;
                  level[i].GetComponent<Image>().color = Color.white;
                }
            }
            level[i].GetComponent<LevelButtonScript>().UpdateStats();

        }
    }



    //Settings Buttons
    public void Sounds()
    {
        if (soundsButton.value==0)
        {
            tempSounds = 0;
            soundsIndicator.text = "Off";

        }
        else  if(soundsButton.value==1)
        {
            
            tempSounds = 1;
            soundsIndicator.text = "On";

        }
    }

   
    public void Music()
    {
        
        if (musicButton.value==0)
        {
            tempMusic = 0;
            musicIndicator.text = "Off";
        }
        else if(musicButton.value==1)
        {
                     
            tempMusic = 1;
            musicIndicator.text = "On";

        }
    }
    public void GraphicsQuality()
    {
        guiNames.UpdateGraphicSlider();
        info_Config.graphics = (int)graphicsSlider.value;
    }
    public void ConfirmPressed()
    {
        //Changing curentlanguage on in use
        info_Config.language = currentLangOnList.text;
        guiNames.UpdateLanguage();

        info_Config.music = tempMusic;
        info_Config.sounds = tempSounds;
        info_Config.graphics = (int)graphicsSlider.value;
        //Closing Setting window
        Close();

        //Close language list if opened
        list.enabled = false;
        englishActive.SetActive(false);
        russianActive.SetActive(false);
        germanActive.SetActive(false);
        chineseActive.SetActive(false);

        //Saving values on opened
       
        
       
    }

    public void Cancel() //Return all values back
    {
        //Changing values in setting menu to start
        graphicsSlider.value = tempGraphicsQual;
        info_Config.graphics = tempGraphicsQual;
        musicButton.value = musicValueTemp;
        soundsButton.value = soundValueTemp;

        musicIndicator.text = OnOffMusic;
        soundsIndicator.text = OnOffSounds;

        //changing active lang
        switch (tempLang)
        {
            case "Chinese": Chinese(); break;
            case "English": English(); break;
            case "German": German(); break;
            case "Russian": Russian(); break;
        }
        //diasbling lang list if opened
        list.enabled = false;
        englishActive.SetActive(false);
        russianActive.SetActive(false);
        germanActive.SetActive(false);
        chineseActive.SetActive(false);

        //deactivating temps
        tempMusic = info_Config.music;
        tempSounds = info_Config.sounds;

        Close();
    }

    //Languages
    public void LanguageList()
    {
        list.enabled = !list.enabled;
        englishActive.SetActive(!englishActive.activeSelf);
        russianActive.SetActive(!russianActive.activeSelf);
        germanActive.SetActive(!germanActive.activeSelf);
        chineseActive.SetActive(!chineseActive.activeSelf);

    }
    public void English()
    {

        activeLang = englishActive;
        ChangeActiveLang(activeLang);
        currentLangOnList.text = "English";

    }
    public void Russian()
    {
        activeLang = russianActive;
        ChangeActiveLang(activeLang);
        currentLangOnList.text = "Russian";

    }
    public void German()
    {
        activeLang = germanActive;
        ChangeActiveLang(activeLang);
        currentLangOnList.text = "German";

    }
    public void Chinese()
    {
        activeLang = chineseActive;
        ChangeActiveLang(activeLang);
        currentLangOnList.text = "Chinese";

    }
    public void ChangeActiveLang(GameObject activeLang)
    {

        englishActive.GetComponent<Image>().enabled = false;
        russianActive.GetComponent<Image>().enabled = false;
        chineseActive.GetComponent<Image>().enabled = false;
        germanActive.GetComponent<Image>().enabled = false;
        activeLang.GetComponent<Image>().enabled = true;
    }
}
