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
    [Header("Finish Window")]
    public LevelRecorder levelRecorder;
    public GameObject finishWindow;
    public Image[] stars = new Image[3];
    public Text finishTime, goldT,usedBladesT;
    


    private void Start()
    {
        GetNames();
        pauseMenu.SetActive(false);
        finishWindow.SetActive(false);

        stars[0].enabled = false;
        stars[1].enabled = false;
        stars[2].enabled = false;
    }

    public void PausePressed(){
        PauseGame();
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    protected void PauseGame()
    {
        Time.timeScale = 0;
    }
    protected void UnPauseGame()
    {
        Time.timeScale = 1;
    }
    public void ResumePressed(){
        UnPauseGame();
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    public void RestartPressed(){
        UnPauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitPressed(){
        UnPauseGame();
        SceneManager.LoadScene(0);
    }

    public void GetNames(){
        currentLang = settingsPref.language;
        //langClassLevel = new Lang(Path.Combine(Application.dataPath, "/Users/macbookproretina/Downloads/Disk F/BladePade/BladePade/Assets/Scenes/MultiLanguage/LanguageDictionary.xml"), currentLang); //macbook
        langClassLevel = new Lang(Path.Combine(Application.dataPath, "C:/Users/Jura/Desktop/BladePade/BladePade/Assets/Scenes/MultiLanguage/LanguageDictionary.xml"), currentLang); //PC
        pauseT.text = langClassLevel.GetString("pause");
        resumeT.text = langClassLevel.GetString("resume");
        restartT.text = langClassLevel.GetString("restart");
        mainMenuT.text = langClassLevel.GetString("main menu");
    }
    public void FinishWindow()
    {
        finishWindow.SetActive(true);
        PauseGame();
        switch (levelRecorder.starsCollected)
        {
            case 1: stars[0].enabled = true; break;
            case 2:
                stars[0].enabled = true;
                stars[1].enabled = true; break;
            case 3:
                stars[0].enabled = true;
                stars[1].enabled = true;
                stars[2].enabled = true; break;
            default:
                stars[0].enabled = false;
                stars[1].enabled = false;
                stars[2].enabled = false;
                break;
        }
        finishTime.text = levelRecorder.ConvertToNormalTimer(levelRecorder.finishTime);
        goldT.text = levelRecorder.coins.ToString();
        usedBladesT.text = levelRecorder.usedBlades.ToString();
        //crystals
    }
    public void Continue()
    {
        UnPauseGame();
        SceneManager.LoadScene(0);
    }

}
