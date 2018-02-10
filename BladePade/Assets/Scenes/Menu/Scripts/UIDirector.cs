using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDirector : MonoBehaviour {
    //Main Menu

    public Canvas mainMenu,shopMenu,donationShopMenu,levelMenu,settingsMenu;

    //In Level Menu

    public Image chooseLevels,chooseChapters;
    public Button buttonToChapter1;

    //Savings Methods

    public delegate void LastMethod();
    LastMethod lastMethod;

    //Settings Buttons

    public bool sounds,music;
    public int graphicsQual;
    public Image soundsButton,musicButton;
    public Text soundsIndicator,musicIndicator,graphicalIndicator;
    public Slider graphicsSlider;

    //Language List

    public GameObject englishActive, russianActive, germanActive, chineseActive,activeLang;
    public Image list,hiddenList;
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


        buttonToChapter1 = buttonToChapter1.GetComponent<Button>();
        buttonToChapter1.enabled = false;
        // Settings 
        soundsButton = soundsButton.GetComponent<Image>();
        soundsIndicator = soundsIndicator.GetComponent<Text>();
        musicButton = musicButton.GetComponent<Image>();
        musicIndicator = musicIndicator.GetComponent<Text>();
        graphicsSlider = graphicsSlider.GetComponent<Slider>();
        graphicalIndicator = graphicalIndicator.GetComponent<Text>();

        //Language

        list = list.GetComponent<Image>();
        hiddenList = hiddenList.GetComponent<Image>();

        currentLangOnList = currentLangOnList.GetComponent<Text>();

        list.enabled = false;

        englishActive.SetActive(false);
        russianActive.SetActive(false);
        germanActive.SetActive(false);
        chineseActive.SetActive(false);



        //
        activeLang = englishActive;


	}
    //MENU
    public void ToShop()
    {
        mainMenu.enabled = !mainMenu.enabled;
        shopMenu.enabled = !shopMenu.enabled;
        lastMethod = ToShop;
    }

    public void ToDonationShop()
    {
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
        mainMenu.enabled = !mainMenu.enabled;
        levelMenu.enabled = !levelMenu.enabled;
        buttonToChapter1.enabled = !buttonToChapter1.enabled;

        chooseLevels.enabled = false;
        chooseChapters.enabled = !chooseChapters.enabled;
        lastMethod = ToLevelMenu;

    }
    public void ChooseLevels()
    {
        chooseChapters.enabled = !chooseChapters.enabled;
        chooseLevels.enabled = !chooseLevels.enabled;
        buttonToChapter1.enabled = !buttonToChapter1.enabled;
        lastMethod = ChooseLevels;
    }
    public void Settings()
    {
        currentLangOnList.text = guiNames.currentLang;
        settingsMenu.enabled = !settingsMenu.enabled;
        lastMethod = Settings;
    }
    //Settings Buttons
    public void Sounds()
    {
        if(!sounds){
            soundsButton.transform.position += new Vector3(soundsButton.rectTransform.rect.width,0,0);
            sounds = !sounds;
            soundsIndicator.text = "On";
        }else{
            soundsButton.transform.position -= new Vector3(soundsButton.rectTransform.rect.width, 0, 0);
            sounds = !sounds;
            soundsIndicator.text = "Off";
        }
    }
    public void Music()
    {
        if (!music)
        {
            musicButton.transform.position += new Vector3(musicButton.rectTransform.rect.width, 0, 0);
            music = !music;
            musicIndicator.text = "On";
        }
        else
        {
            musicButton.transform.position -= new Vector3(musicButton.rectTransform.rect.width, 0, 0);
            music = !music;
            musicIndicator.text = "Off";
        }
    }
    public void GraphicsQuality()
    {
        switch(graphicsSlider.value.ToString())
        {
            case"0":graphicsQual = 0;graphicalIndicator.text = guiNames.langClass.GetString("low");break; //GUINames - access to dictionary
            case"1":graphicsQual = 1;graphicalIndicator.text = guiNames.langClass.GetString("mid");break;
            case"2":graphicsQual = 2;graphicalIndicator.text = guiNames.langClass.GetString("high");break;
        }
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
        guiNames.currentLang = currentLangOnList.text;
    }
    public void Russian(){
        activeLang = russianActive;
        ChangeActiveLang(activeLang);
        currentLangOnList.text = "Russian";
        guiNames.currentLang = currentLangOnList.text;
    }
    public void German(){
        activeLang = germanActive;
        ChangeActiveLang(activeLang);
        currentLangOnList.text = "German";
        guiNames.currentLang = currentLangOnList.text;
    }
    public void Chinese(){
        activeLang = chineseActive;
        ChangeActiveLang(activeLang);
        currentLangOnList.text = "Chinese";
        guiNames.currentLang = currentLangOnList.text;
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
