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
        
        //skin cost
        skin[0] = new Skin(skinPrev[0], 0,1000);       
        skin[1] = new Skin(skinPrev[1], 500, 0);
        skin[2] = new Skin(skinPrev[2], 1000, 0);
        skin[3] = new Skin(skinPrev[3], 2500, 0);
        skin[4] = new Skin(skinPrev[4], 5000, 2000);
        skin[5] = new Skin(skinPrev[5], 10000, 0);
        skin[6] = new Skin(skinPrev[6], 25000, 10000);
        //

        //weapon cost
        weapon[0] = new Skin(weaponPrev[0], 100, 0);
        weapon[1] = new Skin(weaponPrev[1], 500, 0);
        weapon[2] = new Skin(weaponPrev[2], 1000, 0);
        weapon[3] = new Skin(weaponPrev[3], 2500, 1000);
        weapon[4] = new Skin(weaponPrev[4], 5000, 0);
        weapon[5] = new Skin(weaponPrev[5], 10000, 0);
        weapon[6] = new Skin(weaponPrev[6], 25000, 10000);
        //
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
            playerDB.gold -= skin[currentID].gold;
            playerDB.diamonds -= skin[currentID].diamonds;
            playerDB.skinID = currentID;
            skin[currentID] = new Skin(skin[currentID].SkinPrev, 0, 0);
            UpdateSkin();
            guiNames.UpdateBalance();
        } 
        else {}
        if(!category &&(playerDB.gold >= weapon[currentID].gold && playerDB.diamonds >= weapon[currentID].diamonds)) 
        {
            playerDB.gold -= weapon[currentID].gold;
            playerDB.diamonds -= weapon[currentID].diamonds;
            playerDB.weaponID = currentID;
            weapon[currentID] = new Skin(weapon[currentID].SkinPrev, 0, 0);
            UpdateSkin();
            guiNames.UpdateBalance();
        }
        else {}
    }
    public void UpdateSkin(){
        if (category)
        {
            
            skinPlace.sprite = skin[currentID].SkinPrev;
            gold.text = skin[currentID].gold.ToString();
            diamonds.text = skin[currentID].diamonds.ToString();
            NotEnoughMoneyCheck();
            
        }else{
            skinPlace.sprite = weapon[currentID].SkinPrev;
            gold.text = weapon[currentID].gold.ToString();
            diamonds.text = weapon[currentID].diamonds.ToString();
            NotEnoughMoneyCheck();
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
