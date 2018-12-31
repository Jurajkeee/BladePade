using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanging : MonoBehaviour {

	// Use this for initialization
    //Using Example
	public void GoToSceneOne()
    {
        StartCoroutine(LoadAfterTimer("FirstScene", "LoadingScreen"));
    }
    public void GoToSceneTwo()
    {
        StartCoroutine(LoadAfterTimer("SecondScene", "LoadingScreen"));
    }

    //Realization
    private IEnumerator LoadAfterTimer(string levelName, string loadingScreenName)
    {
        LoadScene(loadingScreenName, LoadSceneMode.Additive);
        yield return new WaitForSeconds(2.0f);
        LoadScene(levelName);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadScene(string name, LoadSceneMode loadSceneMode)
    {
        SceneManager.LoadScene(name, loadSceneMode);
    }
}


