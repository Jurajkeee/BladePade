using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDirector : MonoBehaviour
{
    [Header("Main Menu")]
    #region "Window Director Vars"
    //Main Menu
    
    public Canvas mainMenu;
    public Canvas shopMenu, donationShopMenu, levelMenu, settingsMenu;

    #region "Better Close Vars"
    //Savings Methods

    public delegate void LastMethod();

    LastMethod lastMethod;
    #endregion
    #endregion
    [Space(20)][Header("Map Menu")]
    #region "Map Window Vars"
    //In Level Menu
    
    public Image chooseLevels;
    public Image chooseChapters;
    public Button buttonToChapter1;
    public GameObject levelsListC1, levelsListMenu;

    #region "Levels"
    [Header("Levels Menu")]
    public LevelButtonScript[] level;
    public int ToLevelID = 12;
    public Image playButton;
    #endregion

    #endregion   
    [Space(20)][Header("Settings Menu")]
    #region "Settings Window Vars"
    
    //Cancel and Confirm in Setting menu
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

        buttonToChapter1 = buttonToChapter1.GetComponent<Button>();
        buttonToChapter1.enabled = false;

        
        #region "LevelsWindow"
        for (int i =0; i<level.Length; i++)
        {           
            level[i].UpdateStats();
        }
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

        musicGOTemp = musicButton.transform.position;
        soundGOTemp = soundsButton.transform.position;

        OnOffMusic = musicIndicator.text;
        OnOffSounds = soundsIndicator.text;

        tempGraphicsQual = graphicQuality; //Save begin value
        tempLang = guiNames.currentLang;
    }

    //Map
    public void ToLevelMenu()
    {
        settingsButton.enabled = !settingsButton.enabled;
        mainMenu.enabled = !mainMenu.enabled;
        levelMenu.enabled = !levelMenu.enabled;
        buttonToChapter1.enabled = !buttonToChapter1.enabled;

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
        buttonToChapter1.enabled = !buttonToChapter1.enabled;
        lastMethod = ChooseLevels;
        levelsListC1.SetActive(!levelsListC1.activeSelf);
        levelsListMenu.SetActive(false);
    }
    public void LevelsList() //Levels Menu
    {
        lastMethod = LevelsList;
        levelsListMenu.SetActive(!levelsListMenu.activeSelf);
        ToLevelID = 20;
    }
    public void PlayButton()
    {
        if (ToLevelID < 10) {} else Debug.Log("Error with ID");
    }
    public void UpdatePlayButton()
    {
        if (ToLevelID > 10) { playButton.color = new Color(1, 0.5f, 0.5f); playButton.GetComponent<Button>().enabled = false; }
        else { playButton.color = Color.white; playButton.GetComponent<Button>().enabled = true; }
    }


    //Settings Buttons
    public void Sounds()
    {
        if (!tempSounds)
        {
            soundsButton.transform.position += new Vector3(soundsButton.rectTransform.rect.width, 0, 0);
            tempSounds = !tempSounds;
            soundsIndicator.text = "On";
        }
        else
        {
            soundsButton.transform.position -= new Vector3(soundsButton.rectTransform.rect.width, 0, 0);
            tempSounds = !tempSounds;
            soundsIndicator.text = "Off";
        }
    }
    public void Music()
    {
        if (!tempMusic)
        {
            musicButton.transform.position += new Vector3(musicButton.rectTransform.rect.width, 0, 0);
            tempMusic = !tempMusic;
            musicIndicator.text = "On";
        }
        else
        {
            musicButton.transform.position -= new Vector3(musicButton.rectTransform.rect.width, 0, 0);
            tempMusic = !tempMusic;
            musicIndicator.text = "Off";
        }
    }
    public void GraphicsQuality()
    {
        guiNames.UpdateGraphicSlider();
        graphicQuality = (int)graphicsSlider.value;

    }
    public void ConfirmPressed()
    {
        //Changing curentlanguage on in use
        guiNames.currentLang = currentLangOnList.text;
        guiNames.UpdateLanguage();

        //Closing Setting window
        Close();

        //Close language list if opened
        list.enabled = false;
        englishActive.SetActive(false);
        russianActive.SetActive(false);
        germanActive.SetActive(false);
        chineseActive.SetActive(false);

        //Saving values on opened
        music = tempMusic;
        sounds = tempSounds;

        graphicQuality = (int)graphicsSlider.value;
    }
    public void Cancel() //Return all values back
    {
        //Changing values in setting menu to start
        graphicsSlider.value = tempGraphicsQual;
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
        tempMusic = music;
        tempSounds = sounds;

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
