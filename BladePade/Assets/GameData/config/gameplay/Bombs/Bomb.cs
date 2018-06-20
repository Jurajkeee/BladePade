using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public PlayerStats playerMethodsAssembly;
    public float delayBeforeExplosion;
    private bool playerInRadiusOfExplosion;

    private void Start()
    {
        StartCoroutine(Explode(delayBeforeExplosion));
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
            playerInRadiusOfExplosion = true;
        else
            playerInRadiusOfExplosion = false;
    }
    IEnumerator Explode(float seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        if (playerInRadiusOfExplosion) playerMethodsAssembly.KillMe();
        Destroy(this.gameObject);
    }
}
