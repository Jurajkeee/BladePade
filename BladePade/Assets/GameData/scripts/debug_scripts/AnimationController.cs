using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour {

    public Image[] animations;
    public bool on;

	void Start () {
        for (int i = 0; i < animations.Length; i++) animations[i] = animations[i].GetComponent<Image>();
	}
    void Update()
    {
        //Debug.Log(1 / Time.deltaTime);
        if (!on)
        {
            for (int i = 0; i < animations.Length; i++)
            {
                animations[i].enabled=false;
            }
        } else{
            for (int i = 0; i < animations.Length; i++)
            {
                animations[i].enabled = true;
            }
        }

    }

}
