using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    public PlayerStats playerMethodsAssemble;
    private bool isCollide;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && !isCollide)
        {
            isCollide = true;
            playerMethodsAssemble.KillMe();
            //Debug.Log("Interaction on: " + DateTime.Now.Millisecond);
        }
    }
	private void OnCollisionExit2D(Collision2D collision)
	{
        if (collision.transform.tag == "Player")
        isCollide = false;
	}
}
