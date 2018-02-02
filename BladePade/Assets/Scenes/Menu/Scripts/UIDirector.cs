using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDirector : MonoBehaviour {

    public Canvas mainMenu,shopMenu,donationShopMenu,levelMenu;

    //In Level Menu
    public Image chooseLevels,chooseChapters,backToChapters,toMainMenu;

    public Button button;

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

        backToChapters = backToChapters.GetComponent<Image>();
        toMainMenu = toMainMenu.GetComponent<Image>();

        backToChapters.enabled = false;
        toMainMenu.enabled = false;

        button = button.GetComponent<Button>();
        button.enabled = false;

	}
    public void ToShop()
    {
        mainMenu.enabled = false;
        shopMenu.enabled = true;
    }
    public void ToMainMenu()
    {
        shopMenu.enabled = false;
        mainMenu.enabled = true;
        donationShopMenu.enabled = false;
    }
    public void ToDonationShop()
    {
        mainMenu.enabled = false;
        donationShopMenu.enabled = true;
    }
    public void ToLevelMenu()
    {
        mainMenu.enabled = false;
        levelMenu.enabled = true;
        button.enabled = true;//Need To Chamge

        chooseLevels.enabled = false;
        chooseChapters.enabled = true;

        //Міняємо кнопку закриття цілого меню на кнопку закриття вибору рівнів
        toMainMenu.enabled = true;
        backToChapters.enabled = false;
    }
    public void ChooseLevels()
    {
        chooseChapters.enabled = false;
        chooseLevels.enabled = true;
        button.enabled = false;//Need To Change

        //Міняємо кнопу закриття вибору рівнів на кнопку закриття цілого меню

        backToChapters.enabled = true;
        toMainMenu.enabled = false;
    }




}
