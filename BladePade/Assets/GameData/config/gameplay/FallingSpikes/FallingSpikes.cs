using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class FallingSpikes : MonoBehaviour {
    public GameObject trigger; //When player step on it spikes is going to fall on you
     
    private int layerMask,layerMask2;
     //Check if collide with player

    private void Start()
    {
        layerMask = 1 << 8 | 1 << 2;

        layerMask2 =  1 << 0;
        
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }
    private void Update()
    {
        RaycastHit2D buttonRaycast = Physics2D.Raycast(trigger.transform.position, Vector2.up, trigger.transform.localScale.x * 1.1f, layerMask);
        RaycastHit2D hitRaycast = Physics2D.Raycast(transform.position, Vector2.down, this.gameObject.transform.localScale.x * 0.1f, layerMask2);

        if (buttonRaycast.collider)
        {
            SpikesFall();
        }
     
        if (hitRaycast.collider)
        {
            Debug.Log("NORMAL");
            Destroy(this.gameObject.GetComponent<HitBox>());
        }

        Debug.DrawRay(trigger.transform.position, Vector2.up * trigger.transform.localScale.x * 1.1f, Color.red);
        Debug.DrawRay(transform.position, Vector2.down * this.gameObject.transform.localScale.x * 0.1f, Color.red);
    }
    public void SpikesFall()
    {
        if (this.gameObject.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.None)
        {           
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
           
            
        }
        
    }
}
