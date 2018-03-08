using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {

    public float FPS;
    public float BestFPS;
    public float LowFPS;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
       FPS = (1 / Time.deltaTime);
        if (FPS > BestFPS) BestFPS = FPS;
        if (FPS < LowFPS) LowFPS = FPS;
	}
}
