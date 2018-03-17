using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class BladePrefs : MonoBehaviour {

    private Rigidbody2D body;   

    private Vector3 freezedPos;
    private Quaternion freezedRotation;

    [HideInInspector]
    public bool isFreezed=false;

    public float angle;
    public float randomAngle;


    [HideInInspector]
    public float sword_distance;
    private int layerMask;
    

    void Start () {
        
        body = GetComponent<Rigidbody2D>(); 
        layerMask = 1 << gameObject.layer | 1 << 2;
        layerMask = ~layerMask;

        randomAngle = Random.Range(-5f, 5f);
    }

    bool IsAppropriateSide() //Fixed bugs when freezing blade on handle side
    {       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * transform.localScale.x, sword_distance, layerMask);
        if (hit.collider) return true; else return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground") && IsAppropriateSide())
        {          
            body.constraints = RigidbodyConstraints2D.FreezePosition; //freezing position
            freezedPos = transform.position;
            freezedRotation = transform.rotation;
            isFreezed = true;


            GetComponent<Animator>().SetBool("FlyingBlade", false);//Fixed bugs when rotating in the ground
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
        } 
        GetComponent<Animator>().SetBool("FlyingBlade", false);
    }



    private void OnCollisionExit2D(Collision2D collision)
    {      
        if (collision.gameObject.tag == ("Ground")&& !IsAppropriateSide())
        {
            body.constraints = RigidbodyConstraints2D.None; //unfreezing position
            isFreezed = false;
            GetComponent<Animator>().SetBool("FlyingBlade", false);   //Fixed bugs when rotating in the ground

        }       
    }

    private void Update()
    {
        if (isFreezed == true)  //unfreezing
        {
            transform.position = new Vector3(freezedPos.x, freezedPos.y, 2);
            transform.rotation = Quaternion.Euler(freezedRotation.x, freezedRotation.y, freezedRotation.z + randomAngle);

        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + randomAngle), 1f);
        Debug.DrawRay(transform.position, Vector2.right*sword_distance*transform.localScale.x, Color.red);

    }

}
