using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDirector : MonoBehaviour {
    //Main Menu
    public Canvas mainMenu,shopMenu,donationShopMenu,levelMenu;
    //In Level Menu
    public Image chooseLevels,chooseChapters;
    public Button buttonToChapter1;
    //Savings Methods
    public delegate void LastMethod();
    LastMethod lastMethod;

	void Start () {

        mainMenu= mainMenu.GetComponent<Canvas>();
        shopMenu = shopMenu.GetComponent<Canvas>();
        donationShopMenu = donationShopMenu.GetComponent<Canvas>();
        levelMenu = levelMenu.GetComponent<Canvas>();

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

	}
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

}
