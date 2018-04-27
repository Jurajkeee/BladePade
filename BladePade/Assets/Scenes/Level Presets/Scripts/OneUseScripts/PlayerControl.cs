using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    [Space(4)] [TextArea] public string description;[Space(4)]
    
   // [HideInInspector]
    public bool MoveLeft,MoveRight;
   // [HideInInspector]
    public bool isRunning, jump;


    [Header("Behaviors")]
    [Space(5)]  
    public float speed; // скорость движения
    public float acceleration; // ускорение
    public float jumpForce; // сила прыжка
    public float jumpDistance; // расстояние от центра объекта, до поверхности (определяется вручную в зависимости от размеров спрайта)
    [Space(2)]
    public GameObject core;
    [Space(5)][HideInInspector]
    public float h;
    [HideInInspector]
    public bool facingRight = true; // в какую сторону смотрит персонаж на старте?

    private Vector3 direction;
    private int layerMask;
    private Rigidbody2D body;



    void Start() {      
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        layerMask = 1 << gameObject.layer | 1 << 11;
        layerMask = ~layerMask;        
	}

    bool GetJump() // проверяем, есть ли коллайдер под ногами
    {
        bool result = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, jumpDistance, layerMask);
        if (hit.collider)
        {
                result = true;
        }
        return result;
    }

    void FixedUpdate()
    {
        if (MoveLeft || MoveRight)
        {
            //body.constraints = RigidbodyConstraints2D.None;
            body.AddForce(direction * body.mass * speed * acceleration);

            if (Mathf.Abs(body.velocity.x) > speed)
            {
                body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
            }
        }
        //else body.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
    void Flip() // отражение по горизонтали
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * jumpDistance, Color.red); // подсветка, для визуальной настройки jumpDistance
        direction = new Vector2(h, 0);       
        if (h > 0 && !facingRight) Flip(); else if (h < 0 && facingRight) Flip();
    }
    public void Jump(){
        if (GetJump())
        {
            body.velocity = new Vector2(0, jumpForce);
        } 
    }
}
