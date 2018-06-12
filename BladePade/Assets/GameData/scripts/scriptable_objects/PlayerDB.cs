using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Preferences", menuName = "Player Preferences")]
public class PlayerDB : ScriptableObject
{
    [Header("Balance")]
    public int gold;
    public int diamonds;
    [Space(10)][Header("Skins")]
    public int skinID;
    public int weaponID;

    public bool TakeGold(int toTake){
        if (toTake > gold) return false;else{
            gold -= toTake;
            return true;
        }
    }
    public bool TakeDiamonds(int toTake){
        if (toTake > diamonds) return false;
        else
        {
            diamonds -= toTake;
            return true;
        }  
    }


}