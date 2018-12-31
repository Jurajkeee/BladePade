using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    Animator animator;
    PlayerControl player;
    Rigidbody2D body;

    public float yVelocity;
    public float xVelocity;
	void Start () {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<PlayerControl>();
        body = GetComponentInParent<Rigidbody2D>();       
	}
	
	// Update is called once per frame
	void Update () {
        yVelocity = body.velocity.y;
        xVelocity = body.velocity.x;
        if (body.velocity.y > 0.01)
            RunAnimationInstantly("Jump");

        if (body.velocity.y < -0.1)
            RunAnimationInstantly("JumpDown");

        if ((!player.MoveLeft && !player.MoveRight) && (body.velocity.y <= .9f && body.velocity.y >= -.9f))
            RunAnimationInstantly("Standing");

        if ((player.MoveLeft || player.MoveRight) && (body.velocity.y <= .9f && body.velocity.y >= -.9f))
            RunAnimationInstantly("Run");
    }
    void RunAnimationInstantly(string toRun)
    {
        DisableParametersAnimator();
        animator.SetBool(toRun, true);
    }
    private void DisableParametersAnimator()
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.SetBool(parameter.name, false);
        }
    }
}
