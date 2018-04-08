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

    public void SkinIsBought(PlayerDB playerDB)
    {
        playerDB.TakeGold(gold);
        playerDB.diamonds -= diamonds;
        
        isBought = true;
    } 
}
