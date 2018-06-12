using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {

    public PlayerStats playerActions;
    
    bool isActivated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (!isActivated)
            {
                playerActions.SpawnPointRegistration();

                this.GetComponent<Animator>().SetBool("Active", true);

                isActivated = true;
            }
        }
    }
}
