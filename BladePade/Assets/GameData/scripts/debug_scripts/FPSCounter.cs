using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {

    public float FPS;
    public float BestFPS;
    public float LowFPS;

    public Text fpsIndicator;
    public Text bestFpsIndicator;
    public Text lowFpsIndicator;


	
	
	void Update () {
        
       FPS = (1 / Time.deltaTime);
        if (FPS > BestFPS) BestFPS = FPS;
        if (FPS < LowFPS || LowFPS<=10) LowFPS = FPS;

        fpsIndicator.text = FPS.ToString();
        bestFpsIndicator.text = BestFPS.ToString();
        lowFpsIndicator.text = LowFPS.ToString();
	}
    public void ClicledOnMe()
    {
        Debug.Log("Clicked");
    }
}
