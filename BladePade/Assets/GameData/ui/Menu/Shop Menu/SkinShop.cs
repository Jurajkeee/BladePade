using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinShop : MonoBehaviour {
    
    public Skin[] skin = new Skin[7];
    public Skin[] weapon = new Skin[7];
    public Sprite[] skinPrev = new Sprite[7];
    public Sprite[] weaponPrev = new Sprite[7];

    public int currentID;
    public bool category=true; // true-armor false-weapon

    //UI
    public Image weapon_skin_place,armourButton,weaponButton,buyButton;
    public Text gold, diamonds;
    //

    //Player Data Base
    public PlayerDB playerDB;
    public GUINames guiNames;
    public UIDirector ui_director;
    public SkinsLoader skins_loader;
   
    public info_config_scriptable_object info_Config;
	void Start () {
        info_Config = Resources.Load<info_config_scriptable_object>("InfoConfig");
        UpdateSkin();
        armourButton.color = new Color(0.85f, 0.85f, 0.85f);
	}
    public void Left(){
        if(currentID!=0){
            --currentID;
            UpdateSkin();
        }
    }
    public void Right(){
        if (currentID != 6)
        {
            ++currentID;
            UpdateSkin();
        } 
    }

    public void Buy(){
        if (category && (info_Config.gold >= skin[currentID].gold && info_Config.diamonds >= skin[currentID].diamonds))
        {
            if (!info_Config.mySkins.Contains(currentID))
            {
                guiNames.UpdateBalance();
                skin[currentID].SkinIsBought(playerDB);

                info_Config.mySkins.Add(currentID);
                info_Config.currentSkin = currentID;
                
                UpdateSkin();

            }
            else {
                info_Config.currentSkin = currentID;
                UpdateSkin();
                Debug.Log(this.name + ": Using");
            }
        } 
        else {}
        if(!category &&(info_Config.gold >= weapon[currentID].gold && info_Config.diamonds >= weapon[currentID].diamonds)) 
        {
            if (!info_Config.myWeapons.Contains(currentID))
            {
                guiNames.UpdateBalance();
                weapon[currentID].SkinIsBought(playerDB);

                info_Config.myWeapons.Add(currentID);
                info_Config.currentWeapon = currentID;

                UpdateSkin();

            }
            else {
                info_Config.currentWeapon = currentID;
                UpdateSkin();
            }
        }
        else {}
    }
    public void UpdateSkin(){
        if (category)
        {
            weapon_skin_place.enabled = false;//When choosed skins weapon is disabled
            if (!info_Config.mySkins.Contains(currentID))
            {
                buyButton.color = new Color(1, 1, 1, 1);
                guiNames.buyT.text = guiNames.buy;
                skins_loader.UpdateSkin(currentID);
                gold.text = skin[currentID].gold.ToString();
                diamonds.text = skin[currentID].diamonds.ToString();
                NotEnoughMoneyCheck();

            }
            else
            {
                
                skins_loader.UpdateSkin(currentID);
                gold.text = "0";
                diamonds.text = "0";
                isAlreadyBought();
                isAlreadyWeared();
            }
            
        }else{
            weapon_skin_place.enabled = true; //When choosed weapons weapon is enabled
            if (!info_Config.myWeapons.Contains(currentID))
            {
                buyButton.color = new Color(1, 1, 1, 1);
                guiNames.buyT.text = guiNames.buy;
                weapon_skin_place.sprite = weapon[currentID].SkinPrev;
                gold.text = weapon[currentID].gold.ToString();
                diamonds.text = weapon[currentID].diamonds.ToString();
                NotEnoughMoneyCheck();
            }
            else
            {
                weapon_skin_place.sprite = weapon[currentID].SkinPrev;
                gold.text = "0";
                diamonds.text = "0";
                isAlreadyBought();
                isAlreadyWeared();
            }
        }
       
    }
    public void NotEnoughMoneyCheck()
    {
        if (info_Config.gold < skin[currentID].gold || info_Config.diamonds < skin[currentID].diamonds)
        {
            buyButton.color = new Color(1,0.5f,0.5f);
            Debug.Log(this.name + ": Not enough money");
        }
        else buyButton.color = Color.white;
    }
    public void isAlreadyBought()
    {
        if (category)
        {
            if (info_Config.mySkins.Contains(currentID)) { buyButton.color = new Color(1, 1, 1, 1); guiNames.buyT.text = guiNames.use;}
        }
        else
        {
            if (info_Config.myWeapons.Contains(currentID)) {buyButton.color = new Color(1, 1, 1, 1); guiNames.buyT.text = guiNames.use;}
        }
    }
    public void isAlreadyWeared()
    {
        if (category)
        {
            if (currentID == info_Config.currentSkin)
            {
                guiNames.buyT.text = guiNames.in_use;
                buyButton.color = new Color(1, 1, 0, 1);
            }
        }
        else
        {
            if (currentID == info_Config.currentWeapon)
            {
                guiNames.buyT.text = guiNames.in_use;
                buyButton.color = new Color(1, 1, 0, 1);
            }
        }
    }
   

    public void ArmourButton(){
        ui_director.skinPreview.SetActive(true);
        armourButton.color = new Color(0.85f, 0.85f, 0.85f);
        weaponButton.color = Color.white;
        currentID = 0;
        category = true;
        UpdateSkin();
    }
    public void WeaponButton(){

        ui_director.skinPreview.SetActive(false);
        armourButton.color = Color.white;
        weaponButton.color = new Color(0.85f,0.85f,0.85f);
        currentID = 0;
        category = false;
        UpdateSkin();
    }
 
}
