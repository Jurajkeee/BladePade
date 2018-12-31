using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Extensions : MonoBehaviour {

    public static IEnumerator LoadAfterTimer(int levelID, int loadingScreenID)
    {
        LoadScene(loadingScreenID, LoadSceneMode.Additive);
        yield return new WaitForSeconds(2.0f);
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
}
