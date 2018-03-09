using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDirector : MonoBehaviour
{

    #region "Window Director Vars"
    //Main Menu
    [Header("Main Menu")]
    public Canvas mainMenu;
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
    public SettingsSO settingsPreferences;
    [Space(20)]
    public bool sounds;
    public bool music;//DElete when music
    private bool tempSounds, tempMusic;
    public int graphicQuality;//delete when qual
    private int tempGraphicsQual;
    private string tempLang;

    public string OnOffMusic, OnOffSounds;
    public Vector3 musicGOTemp, soundGOTemp;
    
    // Setting Buttons
    public Image soundsButton, musicButton, settingsButton;
    public Text soundsIndicator, musicIndicator;
    public Slider graphicsSlider;

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

        mainMenu = mainMenu.GetComponent<Canvas>();
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
        soundsButton = soundsButton.GetComponent<Image>();
        soundsIndicator = soundsIndicator.GetComponent<Text>();
        musicButton = musicButton.GetComponent<Image>();
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
        mainMenu.enabled = !mainMenu.enabled;
        shopMenu.enabled = !shopMenu.enabled;
        lastMethod = ToShop;

    }
    public void ToDonationShop()
    {
        settingsButton.enabled = !settingsButton.enabled;
        mainMenu.enabled = !mainMenu.enabled;
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

        musicGOTemp = settingsPreferences.musicButtonPosition;
        soundGOTemp = settingsPreferences.soundsButtonPosition;

        OnOffMusic = musicIndicator.text;
        OnOffSounds = soundsIndicator.text;

        tempGraphicsQual = settingsPreferences.graphics; //Save begin value
        tempLang = guiNames.currentLang;

        graphicsSlider.value = settingsPreferences.graphics;

        tempSounds = settingsPreferences.sound;
        soundsButton.transform.position = settingsPreferences.soundsButtonPosition;
        OnOffMusic = settingsPreferences.OffOnMusic;

        tempMusic = settingsPreferences.music;
        musicButton.transform.position = settingsPreferences.musicButtonPosition;
        OnOffSounds = settingsPreferences.OffOnSound;

        musicIndicator.text = settingsPreferences.OffOnMusic;
        soundsIndicator.text = settingsPreferences.OffOnSound;

    }

    //Map
    public void ToLevelMenu()
    {
        settingsButton.enabled = !settingsButton.enabled;
        mainMenu.enabled = !mainMenu.enabled;
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
        if (!tempSounds)
        {
            soundsButton.transform.position += new Vector3(soundsButton.rectTransform.rect.width, 0, 0);
            tempSounds = !tempSounds;
            OnOffSounds = "On";
            soundsIndicator.text = OnOffSounds;
        }
        else  if(tempSounds)
        {
            soundsButton.transform.position -= new Vector3 (soundsButton.rectTransform.rect.width, 0, 0);
            tempSounds = !tempSounds;
            OnOffSounds = "Off";
            soundsIndicator.text = OnOffSounds;
        }
    }
    public void AudioSliderOff(Image AudioSlider)
    {
        AudioSlider.transform.position -= new Vector3(AudioSlider.rectTransform.rect.width, 0, 0);
    }
    public void AudioSliderOn(Image AudioSlider)
    {
        AudioSlider.transform.position += new Vector3(AudioSlider.rectTransform.rect.width, 0, 0);
    }
    public void Music()
    {
        Debug.Log(musicButton.transform.position.ToString());
        if (!tempMusic)
        {
            musicButton.transform.position += new Vector3(musicButton.rectTransform.rect.width, 0, 0);
            tempMusic = !tempMusic;
            OnOffMusic = "On";
            musicIndicator.text = OnOffMusic;
        }
        else if(tempMusic)
        {
            musicButton.transform.position -= new Vector3(musicButton.rectTransform.rect.width, 0, 0);            
            tempMusic = !tempMusic;
            OnOffMusic = "Off";
            musicIndicator.text = OnOffMusic;
        }
    }
    public void GraphicsQuality()
    {
        guiNames.UpdateGraphicSlider();
        settingsPreferences.graphics = (int)graphicsSlider.value;
    }
    public void ConfirmPressed()
    {
        //Changing curentlanguage on in use
        settingsPreferences.language = currentLangOnList.text;
        guiNames.UpdateLanguage();

        settingsPreferences.musicButtonPosition = musicButton.transform.position;
        settingsPreferences.OffOnMusic = OnOffMusic;
        settingsPreferences.soundsButtonPosition = soundsButton.transform.position;
        settingsPreferences.OffOnSound = OnOffSounds;

        settingsPreferences.music = tempMusic;
        settingsPreferences.sound = tempSounds;
        settingsPreferences.graphics = (int)graphicsSlider.value;
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
        settingsPreferences.graphics = tempGraphicsQual;
        musicButton.transform.position = musicGOTemp;
        soundsButton.transform.position = soundGOTemp;

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
        tempMusic = settingsPreferences.music;
        tempSounds = settingsPreferences.sound;

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
