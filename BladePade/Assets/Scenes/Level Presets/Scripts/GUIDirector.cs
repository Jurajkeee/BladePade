using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GUIDirector : MonoBehaviour {

    public GameObject pauseMenu;

    public Lang langClassLevel;
    public string currentLang;
    public SettingsSO settingsPref;
    public Text pauseT, resumeT, restartT, mainMenuT;

    private void Start()
    {
        GetNames();
        pauseMenu.SetActive(false);
    }

    public void PausePressed(){
        Time.timeScale = 0;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    public void ResumePressed(){
        Time.timeScale = 1;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    public void RestartPressed(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitPressed(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void GetNames(){
        currentLang = settingsPref.language;
        langClassLevel = new Lang(Path.Combine(Application.dataPath, "/Users/macbookproretina/Downloads/Disk F/BladePade/BladePade/Assets/Scenes/MultiLanguage/LanguageDictionary.xml"), currentLang); //macbook
        //langClass = new Lang(Path.Combine(Application.dataPath, "C:/Users/Jura/Desktop/BladePade/BladePade/Assets/Scenes/MultiLanguage/LanguageDictionary.xml"), currentLang); //PC
        pauseT.text = langClassLevel.GetString("pause");
        resumeT.text = langClassLevel.GetString("resume");
        restartT.text = langClassLevel.GetString("restart");
        mainMenuT.text = langClassLevel.GetString("main menu");
    }

}
