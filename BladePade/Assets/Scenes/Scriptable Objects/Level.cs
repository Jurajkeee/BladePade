using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    [Header("Description")]
    public new string name;
    public string description;
    public int levelID;

    [Header("Accessibility")]
    public bool isCompleted;
    public bool isReady;

    [Header("Scores")]
    public string bestTime;   
    public int stars;

    public void LoadScene(){
        Application.LoadLevel(levelID);
    }
}
