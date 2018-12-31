using Anima2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsLoader : MonoBehaviour {

    [Header("~~~~~~ Main Character Body ~~~~~~~")]
    public SpriteMesh core;
    public SpriteMesh head;
    public SpriteMesh left_arm;
    public SpriteMesh left_leg;
    public SpriteMesh right_arm;
    public SpriteMesh right_leg;
    public SpriteMesh hat;
    public GameObject hat_Go;
    public SpriteRenderer hand_sword;
    public SpriteRenderer throwing_blade;
    [Header("~~~~~~ Skins ~~~~~~~")]
    public Skin standart_skin;
    public Skin knight_skin;
    public Skin cooler_knight_skin;
    public Skin ninja_skin;
    public Skin sci_fi_ninja_skin;
    [Header("~~~~~~ Weapons ~~~~~~~")]
    public Skin standart_sword;
    public Skin sword_very_sharp;
    public Skin sword_big;
    public Skin sword_broked;
    public Skin sword_sci_fi;
    [Header("~~~~~~ Preferences ~~~~~~~")]
    public bool load_skins_on_start;

    //Private
    [HideInInspector]
    public int skin;//Skin veriable is set in InfoManager
    [HideInInspector]
    public int weapon;//Same problem

    void GetSkinId()
    {       
            skin = GameObject.Find("Singletone").GetComponent<InfoManager>().current_skin;
            weapon = GameObject.Find("Singletone").GetComponent<InfoManager>().current_weapon; //Not sure about dat
    }
    public void LoadSkin()
    {
        if (load_skins_on_start)
        {
            GetSkinId();
            switch (skin)
            {
                case 0:
                    SetSkinsToSpriteMesh(standart_skin);
                    break;
                case 1:
                    SetSkinsToSpriteMesh(knight_skin);
                    break;
                case 2:
                    SetSkinsToSpriteMesh(cooler_knight_skin);
                    break;
                case 3:
                    SetSkinsToSpriteMesh(ninja_skin);
                    break;
                case 4:
                    SetSkinsToSpriteMesh(sci_fi_ninja_skin);
                    break;
                default:
                    Debug.LogError("Skin not found");
                    break;

            }
        }
    }
    public Sprite GetWeapon()
    {
        if (load_skins_on_start)
        {
            GetSkinId();
            switch (weapon)
            {
                case 0:
                    Debug.Log("Skins Loader: Loading Skin " + standart_sword);
                    return standart_sword.SkinPrev;                   
                case 1:
                    Debug.Log("Skins Loader: Loading Skin " + sword_very_sharp);
                    return sword_very_sharp.SkinPrev;                  
                case 2:
                    Debug.Log("Skins Loader: Loading Skin " + sword_big);
                    return sword_big.SkinPrev;                   
                case 3:
                    Debug.Log("Skins Loader: Loading Skin " + sword_broked);
                    return sword_broked.SkinPrev;                   
                case 4:
                    Debug.Log("Skins Loader: Loading Skin " + sword_sci_fi);
                    return sword_sci_fi.SkinPrev;                    
                default:
                    Debug.LogError("Skin not found");
                    return null;
            }
        }
        return null;
    } 
    public void UpdateSkin(int id)
    {
        switch (id)
        {
            case 0:
                SetSkinsToSpriteMesh(standart_skin);
                break;
            case 1:
                SetSkinsToSpriteMesh(knight_skin);
                break;
            case 2:
                SetSkinsToSpriteMesh(cooler_knight_skin);
                break;
            case 3:
                SetSkinsToSpriteMesh(ninja_skin);
                break;
            case 4:
                SetSkinsToSpriteMesh(sci_fi_ninja_skin);
                break;
            default:
                Debug.LogError("Skin not found");
                break;

        }
    }
    void SetSkinsToSpriteMesh(Skin skin)
    {
        Debug.Log("Skins Loader: Loading Skin " + skin);
        core.sprite = skin.core;
        head.sprite = skin.head;
        left_arm.sprite = skin.left_arm;
        left_leg.sprite = skin.left_leg;
        right_arm.sprite = skin.right_arm;
        right_leg.sprite = skin.right_leg;
        if (skin.hat != null)
        {
            hat_Go.SetActive(true);
            hat.sprite = skin.hat;
            Debug.Log("SkinsLoader: Hat loaded");
        }
        else
        {
            hat_Go.SetActive(false);
            Debug.Log("SkinsLoader:" + skin + " has no hat");
        }
        Debug.Log("Skins Loader: Skin had to be loaded");
    }

}
