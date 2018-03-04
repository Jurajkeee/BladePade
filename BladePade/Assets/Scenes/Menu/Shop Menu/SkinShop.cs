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
    public Image skinPlace,armourButton,weaponButton,buyButton;
    public Text gold, diamonds;
    //

    //Player Data Base
    public PlayerDB playerDB;
    public GUINames guiNames;
   
	void Start () {
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
        if (category && (playerDB.gold >= skin[currentID].gold && playerDB.diamonds >= skin[currentID].diamonds))
        {
            if (skin[currentID].isBought == false)
            {              
                skin[currentID].SkinIsBought(playerDB);
                playerDB.skinID = currentID;

                UpdateSkin();
                guiNames.UpdateBalance();
            } else playerDB.skinID = currentID;
        } 
        else {}
        if(!category &&(playerDB.gold >= weapon[currentID].gold && playerDB.diamonds >= weapon[currentID].diamonds)) 
        {
            if (weapon[currentID].isBought == false)
            {              
                weapon[currentID].SkinIsBought(playerDB);
                playerDB.weaponID = currentID;

                UpdateSkin();
                guiNames.UpdateBalance();
            } else playerDB.weaponID = currentID;
        }
        else {}
    }
    public void UpdateSkin(){
        if (category)
        {
            if (skin[currentID].isBought == false)
            {
                skinPlace.sprite = skin[currentID].SkinPrev;
                gold.text = skin[currentID].gold.ToString();
                diamonds.text = skin[currentID].diamonds.ToString();
                NotEnoughMoneyCheck();
            }
            else
            {
                skinPlace.sprite = skin[currentID].SkinPrev;
                gold.text = "0";
                diamonds.text = "0";
            }
            
        }else{
            if (weapon[currentID].isBought == false)
            {
                skinPlace.sprite = weapon[currentID].SkinPrev;
                gold.text = weapon[currentID].gold.ToString();
                diamonds.text = weapon[currentID].diamonds.ToString();
                NotEnoughMoneyCheck();
            }
            else
            {
                skinPlace.sprite = weapon[currentID].SkinPrev;
                gold.text = "0";
                diamonds.text = "0";
            }
        }
       
    }
    public void NotEnoughMoneyCheck()
    {
        if (playerDB.gold < skin[currentID].gold || playerDB.diamonds < skin[currentID].diamonds)
        {
            buyButton.color = new Color(1,0.5f,0.5f);
        }
        else buyButton.color = Color.white;
    }
    public void ArmourButton(){
        armourButton.color = new Color(0.85f, 0.85f, 0.85f);
        weaponButton.color = Color.white;
        currentID = 0;
        category = true;
        UpdateSkin();
    }
    public void WeaponButton(){
        armourButton.color = Color.white;
        weaponButton.color = new Color(0.85f,0.85f,0.85f);
        currentID = 0;
        category = false;
        UpdateSkin();
    }
 
}
