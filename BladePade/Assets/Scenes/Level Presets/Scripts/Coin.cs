using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public LevelRecorder levelrecorder;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player"){
            Destroy(this.gameObject);
            levelrecorder.starsCollected++;
        }
    }

}
