using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_script : MonoBehaviour {
    public Collider2D leftPatrollingEdge;
    public Collider2D rightPatrollingEdge;
    public Transform imMovingTo;
    [Space(20)]
    public int bodyType;
    public int weaponType;
    [Space(10)]
    public float rangeOfView;
    public float rangeOfHit;
    public int behavior;
    private float speed;
    private int direction;
    //
    private Rigidbody2D body;
    private bool facingRight=true;
    //
    private int layerMask2;
    private RaycastHit2D rangeOfViewRC;
    private RaycastHit2D rangeOfHitRC;
    private bool leavedPatrollingzone;
    private Transform player;
    private PlayerStats eventSystem;
    //
    private animator_npc animator;


    private void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<PlayerStats>();
        player = GameObject.Find("Core").transform;
        direction = 1;
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        //
        Body(bodyType);
        Weapon(weaponType);
        //
        layerMask2 = 1 << 8;
        //
        animator = this.gameObject.GetComponent<animator_npc>();
    }
    private void Update()
    {
        Eyes(rangeOfView, rangeOfHit);
        Legs(behavior);
        Debug.DrawRay(transform.position, player.position - transform.position);
    }

    private void Eyes(float rangeOfView, float rangeOfHit)
    {

        Debug.DrawRay(transform.position, Vector3.right * direction * rangeOfView);
        Debug.DrawRay(transform.position, Vector3.right * direction * rangeOfHit, Color.red);
        if (rangeOfViewRC.collider)
        {
            iCanSeeGG();
            if ((player.position.x - transform.position.x) > 0)
            {
                direction = 1;
                if (!facingRight)
                Flip();
                
                if(bodyType==1){
                    rangeOfHitRC = Physics2D.Raycast(transform.position, Vector3.right * direction, rangeOfHit, layerMask2);
                        if(rangeOfHitRC.collider)
                        {
                            Attack();
                        }
                    }
            }
            else if ((player.position.x - transform.position.x) < 0)
            {
                direction = -1;
                if (facingRight)
                Flip();

                if (bodyType == 1){
                    rangeOfHitRC = Physics2D.Raycast(transform.position, Vector3.right * direction, rangeOfHit, layerMask2);
                        if (rangeOfHitRC.collider)
                        {
                            Attack();
                        }
                }
            }
        }
        else
        {
            iCantSeeGG();

        }
    }

    private void Legs(int status)
    {
        switch (status)
        {
            case 1:
                transform.position += Vector3.right * speed * direction * Time.deltaTime;
                Debug.Log("Walking");
                break;
            case 2:
                transform.position += Vector3.right * speed * direction * 3f * Time.deltaTime;
                Debug.Log("Running");
                break;
            case 3:
                transform.position += Vector3.right * speed * direction * 0 * Time.deltaTime;
                Debug.Log("Stop");
                break;
        }
    }

    private void Attack()//Here can be behavior for thinking if range is good for attack
    {
        if(bodyType==1){
            animator.Hit();
            behavior = 3;
        }
    }
    private void Kill(){
        eventSystem.KillMe();
    }
    private void Body(int type)
    {
        switch (type)
        {
            case 1:
                speed = 0.76f;
                rangeOfView = 5;
                break;
        }
    }
    private void Weapon(int type)
    {
        switch (type)
        {
            case 1:
                break;
        }
    }
    //Reaction Methods
    private void Flip()
    {
        facingRight = !facingRight;
        Debug.Log("Flip " + facingRight);
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    private void iCanSeeGG()
    {
        rangeOfViewRC = Physics2D.Raycast(transform.position, player.position - transform.position, rangeOfView, layerMask2);
        behavior = 2;
        Debug.Log("I've seen him");
        animator.Chase();
    }
    private void iCantSeeGG()
    {
        rangeOfViewRC = Physics2D.Raycast(transform.position, Vector3.right * direction, rangeOfView, layerMask2);
        behavior = 1;
        Debug.Log("Nothing happening");
        if (leavedPatrollingzone) ContinueMoving();
        animator.Walk();


    }
    public void ContinueMoving()
    {
        if (imMovingTo == rightPatrollingEdge.transform)
        {
            leavedPatrollingzone = false;
            direction = 1;
            if(!facingRight)
            Flip();
            Debug.Log("I'm returning for patrolling to right");

        }
        if (imMovingTo == leftPatrollingEdge.transform)
        {
            leavedPatrollingzone = false;
            direction = -1;
            if(facingRight)
            Flip();
            Debug.Log("I'm returning for patrolling to left");
            facingRight = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == leftPatrollingEdge.name && behavior != 2)
        {
            direction = 1;
            rightPatrollingEdge.enabled = true;
            imMovingTo = rightPatrollingEdge.transform;
            Flip();
        }
        else if (collision.transform.name == leftPatrollingEdge.name)
        {
            imMovingTo = rightPatrollingEdge.transform;
            leavedPatrollingzone = true;
            Debug.Log("Im leaving patroll");
            leftPatrollingEdge.enabled = false;
        }

        if (collision.transform.name == rightPatrollingEdge.name && behavior != 2)
        {
            direction = -1;
            leftPatrollingEdge.enabled = true;
            imMovingTo = leftPatrollingEdge.transform;
            Flip();
        }
        else if (collision.transform.name == rightPatrollingEdge.name)
        {
            imMovingTo = leftPatrollingEdge.transform;
            leavedPatrollingzone = true;
            Debug.Log("Im leaving patroll");
            rightPatrollingEdge.enabled = false;
        }


    }


}
