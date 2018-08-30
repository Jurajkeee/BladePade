using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Skin", menuName = "Skin")]
public class Skin:ScriptableObject
{
       
    public Sprite SkinPrev;
    public int gold;
    public int diamonds;
    [Space(10)]
    public bool isBought;
    public info_config_scriptable_object info_Config;


    public void SkinIsBought(PlayerDB playerDB)
    {
        info_Config = Resources.Load<info_config_scriptable_object>("InfoConfig");
        playerDB.TakeGold(gold);
        playerDB.diamonds -= diamonds;
        
        isBought = true;
    } 
}
