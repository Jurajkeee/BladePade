using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fake_ground_script : MonoBehaviour {

    public GameObject fake_ground;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            fake_ground.SetActive(false);
        }
    }
}
