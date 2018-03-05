using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Settings Preferences", menuName = "Settings Preferences")]
public class SettingsSO : ScriptableObject {

    public string language;
    public int graphics;
    public bool music;
    public bool sound;
    [Space(10)]
    public Vector3 musicButtonPosition;
    public string OffOnMusic;
    [Space(10)]
    public Vector3 soundsButtonPosition;
    public string OffOnSound; 
}
