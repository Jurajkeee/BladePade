using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour {
    public PlayerStats playerMethodsAssembly;
    private Animator anim;
    [Space(4)]
    [Header("Actions")]
    public bool stopping;   
    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (stopping)
             playerMethodsAssembly.SlowMe(true);
        else playerMethodsAssembly.SlowMe(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") anim.SetBool("Closed", true);
    }
}
