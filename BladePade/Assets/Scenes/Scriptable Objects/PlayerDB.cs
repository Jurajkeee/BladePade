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
    void Start()
    {

    }
    void OnApplicationQuit()
    {

    }
}