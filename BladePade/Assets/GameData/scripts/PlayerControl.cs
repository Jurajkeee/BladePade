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

    RaycastHit2D hit_right;
    RaycastHit2D hit_left;

    CapsuleCollider2D capsule_collider_2d;

    void Start() {
        capsule_collider_2d = this.gameObject.GetComponent<CapsuleCollider2D>();
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        layerMask = 1 << gameObject.layer | 1 << 11;
        layerMask = ~layerMask;   

	}

    bool GetJump() // проверяем, есть ли коллайдер под ногами
    {
        bool result = false;

        if (hit_right.collider||hit_left.collider)
                result = true;
        
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
        hit_right = Physics2D.Raycast(new Vector3(transform.position.x + 0.23f, transform.position.y, transform.position.z), Vector3.down, jumpDistance, layerMask);
        hit_left = Physics2D.Raycast(new Vector3(transform.position.x - 0.23f, transform.position.y, transform.position.z), Vector3.down, jumpDistance, layerMask);

        Debug.DrawRay(new Vector3(transform.position.x + 0.23f, transform.position.y, transform.position.z), Vector3.down * jumpDistance, Color.blue); // подсветка, для визуальной настройки jumpDistance
        Debug.DrawRay(new Vector3(transform.position.x - 0.23f, transform.position.y, transform.position.z), Vector3.down * jumpDistance, Color.red); // подсветка, для визуальной настройки jumpDistance

        //Making not stuck on corners by changing friction to zero and reloading it
        if (!hit_left) 
        { 
            capsule_collider_2d.sharedMaterial.friction = 0;
            ReloadCollider();
        } 
        else
        { 
            capsule_collider_2d.sharedMaterial.friction = 3;
            ReloadCollider();
        }

       
              

        direction = new Vector2(h, 0);       
        if (h > 0 && !facingRight) Flip(); else if (h < 0 && facingRight) Flip();
    }
    public void Jump(){
        if (GetJump())
        {
            body.velocity = new Vector2(0, jumpForce);
        } 
    }
    public void ReloadCollider(){
        capsule_collider_2d.enabled = false;
        capsule_collider_2d.enabled = true;
    }
}
