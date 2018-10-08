using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladePrefs : MonoBehaviour {

    private Rigidbody2D body;   

    private Vector3 freezedPos;
    private Quaternion freezedRotation;

    //[HideInInspector]
    public bool isFreezed=false;

    [HideInInspector]
    public float randomAngle;

    [HideInInspector]
    public float sword_distance;
    private int layerMask;

    //Effector

    public bool effectorEnabled;
    public GameObject effector;
    private int effectorLayerMask;
    

    void Start () {
        
        body = GetComponent<Rigidbody2D>(); 

        layerMask = 1 << gameObject.layer | 1 << 11| 1<<2;
        layerMask = ~layerMask;

        effectorLayerMask = 1 << gameObject.layer | 1 <<11 | 1<<2;
        effectorLayerMask = ~effectorLayerMask;
        effector = this.gameObject.transform.GetChild(1).gameObject;

        randomAngle = Random.Range(-5f, 5f);

        this.gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("Singletone").GetComponent<SkinsLoader>().GetWeapon();
    }

    bool IsAppropriateSide() //Fixed bugs when freezing blade on handle side
    {       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * transform.localScale.x, sword_distance, layerMask);
        if (hit)
        {
            if (hit.collider) { return true;}
            else return false;

        }
        else return false;
    }
    
    void Effector(bool enabled)
    {
        if (enabled)
        {          
           effector.SetActive(true);
           effector.transform.rotation = Quaternion.Euler(0,0,0);
           
        }
        else effector.SetActive(false);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground") && IsAppropriateSide())
        {
            this.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            body.constraints = RigidbodyConstraints2D.FreezePosition; //freezing position
            freezedPos = transform.position;
            freezedRotation = transform.rotation;
            isFreezed = true;

            body.bodyType = RigidbodyType2D.Static;

            GetComponent<Animator>().SetBool("FlyingBlade", false);//Fixed bugs when rotating in the ground
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

            effectorEnabled = true;

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
            effectorEnabled = false;
        }       
    }

    private void FixedUpdate()
    {
        if (isFreezed == true)  //unfreezing
        {
            transform.position = new Vector3(freezedPos.x, freezedPos.y, 2);
            transform.rotation = Quaternion.Euler(freezedRotation.x, freezedRotation.y, freezedRotation.z + randomAngle);
        }

        Effector(effectorEnabled);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + randomAngle), 1f);
        
        Debug.DrawRay(transform.position, Vector2.right * sword_distance * transform.localScale.x, Color.red);
    }

}
