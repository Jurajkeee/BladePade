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
    

    

    void Start () {
        body = GetComponent<Rigidbody2D>();       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            body.constraints = RigidbodyConstraints2D.FreezePosition;
            freezedPos = transform.position;
            freezedRotation = transform.rotation;
            isFreezed = true;
            GetComponent<Animator>().SetBool("FlyingBlade", false);
        }
    }

    private void Update()
    {
        if (isFreezed == true)
        {
            transform.position = new Vector3(freezedPos.x, freezedPos.y, 2);
            transform.rotation = freezedRotation;
        }

    }

}
