using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Extensions : MonoBehaviour {

    public static IEnumerator LoadAfterTimer(int levelID, int loadingScreenID)
    {
        
        LoadScene(loadingScreenID, LoadSceneMode.Additive);
        yield return null;
        LoadScene(levelID);
    }
    public static void LoadScene(int ID)
    {
        SceneManager.LoadScene(ID);
    }
    public static void LoadScene(int ID, LoadSceneMode loadSceneMode)
    {
        SceneManager.LoadScene(ID, loadSceneMode);
    }

    public static IEnumerator WaitForRealSeconds(float time)
    {
         float start = Time.realtimeSinceStartup;
         while (Time.realtimeSinceStartup < start + time)
         {
             yield return null;
         }
    }
}
