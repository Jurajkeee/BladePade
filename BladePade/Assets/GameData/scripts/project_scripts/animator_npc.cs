using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator_npc : MonoBehaviour {

    private Animator animator;
	void Start () {
        animator = GetComponent<Animator>();
	}
    public void Hit()
    {
        animator.SetBool("hit", true);
        animator.SetBool("chase", false);
        animator.SetBool("walk", false);
    }
    public void Chase()
    {
        animator.SetBool("hit", false);
        animator.SetBool("chase", true);
        animator.SetBool("walk", false);
    }
    public void Walk()
    {
        animator.SetBool("hit", false);
        animator.SetBool("chase", false);
        animator.SetBool("walk", true);
    }
}
