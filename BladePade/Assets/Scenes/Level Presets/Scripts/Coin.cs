using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public LevelRecorder levelrecorder;

    private bool isCollide = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {         
            Destroy(this.gameObject);
            if (!isCollide)
            {
                levelrecorder.starsCollected++;
                isCollide = true;
            }
        }
        
    }

}
