using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    [Space(4)] [TextArea] public string description;[Space(4)]
    [Space(20)]
    [Header("Behavior")]
    public PlayerControl player;

    private float speed;
    private float jumpForce;
    
    public int lifes;

    private Vector3 spawnPoint;
    private GUIDirector guidirector;
    public bool isDead;

    private void Start()
    {
        guidirector = GetComponent<GUIDirector>();

        spawnPoint = SpawnPoint();
        speed = player.speed;
    }

    public void KillMe()
    {

            lifes--;
            guidirector.UpdateGUI();
            ReSpawn();
            if (lifes <= 0)
            {
                guidirector.GetMoreLivesWindow();
            }
    }
    public void SlowMe(bool slow)
    {
        if (slow) player.speed *= 0.5f; else player.speed = speed;
    }
    public void ReSpawn()
    {
        player.transform.position = spawnPoint;
    }
    private Vector3 SpawnPoint()
    {
        return player.transform.position;
    }
    

    
}
