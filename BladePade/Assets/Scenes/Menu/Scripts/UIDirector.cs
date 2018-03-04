using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
public class UIDirector : MonoBehaviour
{

    #region "Window Director Vars"
    //Main Menu
    [Header("Main Menu")]
    public Canvas mainMenu;
    public Canvas shopMenu, donationShopMenu, levelMenu, settingsMenu;
=======
public class UIDirector : MonoBehaviour {
    //Main Menu
>>>>>>> parent of e8dc61f... 12321

    public Canvas mainMenu,shopMenu,donationShopMenu,levelMenu,settingsMenu;

    //In Level Menu

    public Image chooseLevels,chooseChapters;
    public Button buttonToChapter1;
    public GameObject levelsListC1;
  

    //Savings Methods

    public delegate void LastMethod();
    LastMethod lastMethod;
<<<<<<< HEAD
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
    public bool sounds;
    public bool music;//DElete when music
=======


    //Cancel and Confirm in Setting menu
    public bool sounds,music;//DElete when music
>>>>>>> parent of e8dc61f... 12321
    private bool tempSounds, tempMusic;
    public int graphicQuality;//delete when qual
    private int tempGraphicsQual;
    private string tempLang;

    public string OnOffMusic, OnOffSounds;
    public Vector3 musicGOTemp, soundGOTemp;

    // Setting Buttons
    public Image soundsButton,musicButton,settingsButton;
    public Text soundsIndicator,musicIndicator;
    public Slider graphicsSlider;

<<<<<<< HEAD
     #region "Language List Vars"

    [Header("Languages List")]
    public GameObject englishActive;
    public GameObject russianActive, germanActive, chineseActive, activeLang;
    public Image list, hiddenList;
=======

    //Language List

    public GameObject englishActive, russianActive, germanActive, chineseActive,activeLang;
    public Image list,hiddenList;
>>>>>>> parent of e8dc61f... 12321
    public Text currentLangOnList;

    [SerializeField]
    private GUINames guiNames;

	void Start () {

        guiNames = guiNames.GetComponent<GUINames>();

        mainMenu= mainMenu.GetComponent<Canvas>();
        shopMenu = shopMenu.GetComponent<Canvas>();
        donationShopMenu = donationShopMenu.GetComponent<Canvas>();
        levelMenu = levelMenu.GetComponent<Canvas>();
        settingsMenu = settingsMenu.GetComponent<Canvas>();

        settingsMenu.enabled = false;
        shopMenu.enabled = false;
        donationShopMenu.enabled = false;
        levelMenu.enabled = false;

        //In Level Menu
        chooseChapters = chooseChapters.GetComponent<Image>();
        chooseLevels = chooseLevels.GetComponent<Image>();

        chooseLevels.enabled = false;
        chooseChapters.enabled = false;

<<<<<<< HEAD
        
        buttonToChapter1.SetActive(false);


        #region "LevelsWindow"
        UpdateLevelsStats();
        #endregion
=======

>>>>>>> parent of e8dc61f... 12321


        buttonToChapter1 = buttonToChapter1.GetComponent<Button>();
        buttonToChapter1.enabled = false;
        // Settings 
        soundsButton = soundsButton.GetComponent<Image>();
        soundsIndicator = soundsIndicator.GetComponent<Text>();
        musicButton = musicButton.GetComponent<Image>();
        musicIndicator = musicIndicator.GetComponent<Text>();
        graphicsSlider = graphicsSlider.GetComponent<Slider>();


        settingsButton = settingsButton.GetComponent<Image>();

        //Language

        list = list.GetComponent<Image>();
        hiddenList = hiddenList.GetComponent<Image>();



        list.enabled = false;

        englishActive.SetActive(false);
        russianActive.SetActive(false);
        germanActive.SetActive(false);
        chineseActive.SetActive(false);


	}
    //MENU
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
        if (lastMethod == ChooseLevels) lastMethod = ToLevelMenu;else lastMethod = null;
    }
    public void ToLevelMenu()
    {
        settingsButton.enabled = !settingsButton.enabled;
        mainMenu.enabled = !mainMenu.enabled;
        levelMenu.enabled = !levelMenu.enabled;
        buttonToChapter1.SetActive(!buttonToChapter1.activeSelf);

        levelsListC1.SetActive(false);
        chooseLevels.enabled = false;


        chooseChapters.enabled = !chooseChapters.enabled;
        lastMethod = ToLevelMenu;

    }
    public void ChooseLevels()
    {       
        chooseChapters.enabled = !chooseChapters.enabled;
        chooseLevels.enabled = !chooseLevels.enabled;
        buttonToChapter1.SetActive(!buttonToChapter1.activeSelf);
        lastMethod = ChooseLevels;
        levelsListC1.SetActive(!levelsListC1.activeSelf);
    }
<<<<<<< HEAD
    public void LevelsList() //Levels Menu
    {
        lastMethod = LevelsList;
        levelsListMenu.SetActive(!levelsListMenu.activeSelf);
        ToLevelID = 20;
        UpdateLevelsStats();
    }
    public void PlayButton()
    {
        if (ToLevelID < 10) {} else Debug.Log("Error with ID");
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
                if (!level[i].GetComponent<LevelButtonScript>().level.isReady) { level[i].GetComponent<Button>().enabled = false; } else {level[i].GetComponent<Button>().enabled = true;}
            }
            level[i].GetComponent<LevelButtonScript>().UpdateStats();

        }
    }
=======
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

        tempGraphicsQual = graphicQuality;//Save begin value
        tempLang = guiNames.currentLang;
>>>>>>> parent of e8dc61f... 12321


    }
    //Settings Buttons
    public void Sounds()
    {
        if(!tempSounds){
            soundsButton.transform.position += new Vector3(soundsButton.rectTransform.rect.width,0,0);
            tempSounds = !tempSounds;
            soundsIndicator.text = "On";
        }else{
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
    public void Russian(){
        activeLang = russianActive;
        ChangeActiveLang(activeLang);
        currentLangOnList.text = "Russian";

    }
    public void German(){
        activeLang = germanActive;
        ChangeActiveLang(activeLang);
        currentLangOnList.text = "German";

    }
    public void Chinese(){
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
        switch(tempLang)
        {
            case "Chinese":Chinese();break;
            case "English":English();break;
            case "German":German();break;
            case "Russian":Russian();break;
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
    public void SubChapterButton(){
        
    }




}
