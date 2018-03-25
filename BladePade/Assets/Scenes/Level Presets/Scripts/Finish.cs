using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    public LevelRecorder levelRecorder;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") levelRecorder.Finished();
    }
}
