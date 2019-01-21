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
    public float minJumpDistanceToTheGround; // расстояние от центра объекта, до поверхности (определяется вручную в зависимости от размеров спрайта)
    public float jumpDistance; //сила прыжка относительно оси х
    [Space(2)]
    public GameObject core;
    [Space(5)][HideInInspector]
    public float h;
    [HideInInspector]
    public bool facingRight = true; // в какую сторону смотрит персонаж на старте?

    private Vector3 direction;
    private int layerMask;
    private Rigidbody2D body;

    RaycastHit2D hit_right_ground;
    RaycastHit2D hit_left_ground;

    private RaycastHit2D hit_wall_raycast;
    public float maxLengthToTheWall;
    private int layerMask2;

    CapsuleCollider2D capsule_collider_2d;

    void Start() {
        capsule_collider_2d = this.gameObject.GetComponent<CapsuleCollider2D>();
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        layerMask = 1 << gameObject.layer | 1 << 16 | 1 << 11;
        layerMask = ~layerMask;

        layerMask2 = 1 << 0;
    }

    bool GetJump() // проверяем, есть ли коллайдер под ногами
    {
        bool result = false;
        if (hit_right_ground.collider || hit_left_ground.collider)
        {
            result = true;
        }       
        return result;
    }

    void FixedUpdate()
    {    
        if ((MoveLeft || MoveRight) && !hit_wall_raycast)
        {
            body.AddForce(direction * body.mass * speed * acceleration);
            if (Mathf.Abs(body.velocity.x) > speed) body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
        }
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
        hit_right_ground = Physics2D.Raycast(new Vector3(transform.position.x + 0.23f, transform.position.y, transform.position.z), Vector3.down, minJumpDistanceToTheGround, layerMask);
        hit_left_ground = Physics2D.Raycast(new Vector3(transform.position.x - 0.23f, transform.position.y, transform.position.z), Vector3.down, minJumpDistanceToTheGround, layerMask);

        hit_wall_raycast = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z), Vector2.right * direction, maxLengthToTheWall, layerMask2);
        //Making not stuck on corners by changing friction to zero and reloading it
        if (!hit_left_ground) 
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

        //Debug Code
        Debug.DrawRay(new Vector3(transform.position.x + 0.23f, transform.position.y, transform.position.z), Vector3.down * minJumpDistanceToTheGround, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x - 0.23f, transform.position.y, transform.position.z), Vector3.down * minJumpDistanceToTheGround, Color.red);

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y-0.8f, transform.position.z), Vector2.right * direction * maxLengthToTheWall, Color.blue);

        //~~~~~~~~~~~~~~~~
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
