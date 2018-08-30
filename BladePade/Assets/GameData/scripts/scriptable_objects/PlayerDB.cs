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
    public info_config_scriptable_object info_Config;

    public bool TakeGold(int toTake){
        info_Config = Resources.Load<info_config_scriptable_object>("InfoConfig");
        if (toTake > info_Config.gold) return false;else{
            info_Config.gold -= toTake;
            return true;
        }
    }
    public bool TakeDiamonds(int toTake){
        info_Config = Resources.Load<info_config_scriptable_object>("InfoConfig");
        if (toTake > info_Config.diamonds) return false;
        else
        {
            info_Config.diamonds -= toTake;
            return true;
        }  
    }


}