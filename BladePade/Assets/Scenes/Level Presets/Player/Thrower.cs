﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {
    [Header("Blade")]    
    public GameObject swordPrefab;

    [Space(2)]
    [Header("Behavior")]
    public float speed;
    [Space(2)]
    [Header("Animations")]
    public float minimalDistance;
    public float animation_speed;

    

    void Start () 
    {
		
	}

    public void Throw(Vector3 aimCords)
    {
        Vector2 direction = (Vector2)(Camera.main.ScreenToWorldPoint(aimCords) - transform.position);

        direction.Normalize();
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            GameObject sword = (GameObject)Instantiate(swordPrefab, transform.position + (Vector3)(direction), Quaternion.identity);
                  
            if (angle > 90f || angle < -90f)
            {
                sword.GetComponent<Transform>().transform.localScale = new Vector3(-1, 1);
                sword.transform.rotation = Quaternion.Euler(sword.transform.rotation.x, -sword.transform.rotation.y, angle);
            }
            else {
                sword.GetComponent<Transform>().transform.localScale = new Vector3(1, 1);
                sword.transform.rotation = Quaternion.Euler(sword.transform.rotation.x, sword.transform.rotation.y, angle);
            }
       
            sword.GetComponent<Rigidbody2D>().velocity = direction * speed;
            sword.GetComponent<BladePrefs>().angle = angle;
            
            FlyingPlayBack(sword);
    }
    public void FlyingPlayBack(GameObject blade)
    {
       blade.GetComponent<Animator>().SetBool("FlyingBlade", true);
    }

}
