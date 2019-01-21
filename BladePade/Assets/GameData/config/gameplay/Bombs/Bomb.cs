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
        //Extensions.FindPlayerStats(ref playerMethodsAssembly);
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
        this.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        if (playerInRadiusOfExplosion) { playerMethodsAssembly.KillMe(); Debug.Log("Is Killed"); }
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(Destroy(delayBeforeExplosion));

    }
    IEnumerator Destroy(float seconds){
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
