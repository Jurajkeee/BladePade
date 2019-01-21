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
        //We have to be sure that time after pausing was resumed
        Time.timeScale = 1.0f;
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

    public static IEnumerator DelayForSeconds(float time,  bool finished)
    {
        finished = true;
        yield return new WaitForSeconds(time);

    }
    public static void FindPlayerStats(ref PlayerStats playerStats)
    {
        playerStats = GameObject.Find("EventSystem").GetComponent<PlayerStats>();
        if (playerStats == null)
            FindPlayerStats(ref playerStats);
    }
}
