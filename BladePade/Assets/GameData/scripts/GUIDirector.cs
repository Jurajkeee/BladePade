using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class GUIDirector : MonoBehaviour
{
    [Space(4)] [TextArea] public string description;[Space(4)]
    public GameObject pauseMenu;

    public Lang langClassLevel;
    public string currentLang;
    public SettingsSO settingsPref;
    public Text pauseT, resumeT, restartT, mainMenuT;

    public GameObject controlLayout;

    [Header("Finish Window")]
    [Space(10)]
    public LevelRecorder levelRecorder;
    public GameObject finishWindow;
    public Image[] stars = new Image[3];
    public Text finishTime, goldT, usedBladesT;

    [Header("GameOverWindows")]
    [Space(10)]
    public PlayerStats playerLives;
    public GameObject getMoreLivesCanvas;
    public GameObject getMoreLivesGO, gameOverMenu;

    [Header("GUI")]
    public Text livesCounter;

    private void Start()
    {
        GetNames();
        pauseMenu.SetActive(false);
        finishWindow.SetActive(false);
        playerLives = this.gameObject.GetComponent<PlayerStats>();

        getMoreLivesCanvas.SetActive(false);
        gameOverMenu.SetActive(false);

        stars[0].enabled = false;
        stars[1].enabled = false;
        stars[2].enabled = false;

        UpdateGUI();
    }
    //GUI
    public void UpdateGUI(){
        livesCounter.text = "x"+playerLives.lifes.ToString();
    }

    //Loser Window
    public void GetMoreLivesWindow(){
        getMoreLivesCanvas.SetActive(!getMoreLivesCanvas.activeSelf);
        PauseGame();
    }
    public void CloseGMLW(){
        getMoreLivesGO.SetActive(false);
        gameOverMenu.SetActive(true);
    }
    public void BuyNewLife(){
        if (levelRecorder.playerDB.TakeGold(3000))
        {
            playerLives.lifes++;
            playerLives.ReSpawn();
            getMoreLivesCanvas.SetActive(!getMoreLivesCanvas.activeSelf);
            UnPauseGame();
            UpdateGUI();
        }
        else Debug.Log("NotEnough Gold");
    }

    //Pause Menu
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
    public void PausePressed()
    {
        PauseGame();
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    //Finish Window
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

    //Additional
    public void GetNames()
    {
        currentLang = settingsPref.language;
        langClassLevel = new Lang(currentLang); 
        pauseT.text = langClassLevel.GetString("pause");
        resumeT.text = langClassLevel.GetString("resume");
        restartT.text = langClassLevel.GetString("restart");
        mainMenuT.text = langClassLevel.GetString("main menu");
    }
    protected void PauseGame()
    {
        Time.timeScale = 0;
        ControlLayout();
    }
    protected void UnPauseGame()
    {
        Time.timeScale = 1;
        ControlLayout();
    }
    public void ControlLayout()
    {
        controlLayout.SetActive(!controlLayout.activeSelf);
    }
}
