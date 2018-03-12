using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {

    public GameObject swordPrefab;
   [Space(10)] [Header("Behavior")]
    public float speed;

    private float timestamp;
    public float timeBetweenShoot = 0.3333f;
    

    void Start () 
    {
		
	}

    public void Throw(Vector3 aimCords)
    {
        Vector2 direction = (Vector2)(Camera.main.ScreenToWorldPoint(aimCords) - transform.position);
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Time.time >= timestamp)
        {
            GameObject sword = (GameObject)Instantiate(swordPrefab, transform.position + (Vector3)(direction * 0.5f), Quaternion.identity);
            if (angle > 90f || angle < -90f)
            {

                sword.GetComponent<Transform>().transform.localScale = new Vector3(1, -1);
                sword.transform.rotation = Quaternion.Euler(sword.transform.rotation.x, -sword.transform.rotation.y, angle);
            }
            else { 
            sword.transform.rotation = Quaternion.Euler(sword.transform.rotation.x, sword.transform.rotation.y, angle);
            }

            

            sword.GetComponent<Rigidbody2D>().velocity = direction * speed;
            timestamp = Time.time + timeBetweenShoot;
            
        }
    }


}
