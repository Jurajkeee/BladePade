using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Skin", menuName = "Skin")]
public class Skin:ScriptableObject
{
    [Header("~~~~~~~~~~~~~~~ Menu variables ~~~~~~~~~~~~~~~~~")]   
    public Sprite SkinPrev;
    public int gold;
    public int diamonds;
    [Space(10)]
    public bool isBought;
    public info_config_scriptable_object info_Config;
    [Header("~~~~~~~~~~~~~~~ In Game Variables ~~~~~~~~~~~~~~~~~")]
    public Sprite core;
    public Sprite head;
    public Sprite left_arm;
    public Sprite left_leg;
    public Sprite right_arm;
    public Sprite right_leg;
    public Sprite hat;

    public void BuySkin(PlayerDB playerDB)
    {
        info_Config = Resources.Load<info_config_scriptable_object>("InfoConfig");
        playerDB.TakeGold(gold);
        playerDB.TakeDiamonds(diamonds);
        
        isBought = true;
    } 
}
