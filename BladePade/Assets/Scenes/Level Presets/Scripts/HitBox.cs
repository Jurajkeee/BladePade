using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    public PlayerStats playerMethodsAssemble;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player") playerMethodsAssemble.KillMe();
    }
}
