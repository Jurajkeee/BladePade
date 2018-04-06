using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    [Space(20)]
    [Header("Behavior")]
    public PlayerControl player;

    private float speed;
    private float jumpForce;
    
    public int lifes;

    private Vector3 spawnPoint;
    private void Start()
    {        
        spawnPoint = SpawnPoint();
        speed = player.speed;
        Debug.Log(spawnPoint);
    }

    public void KillMe()
    {
        lifes--;
        ReSpawn();
    }
    public void SlowMe(bool slow)
    {
        if (slow) player.speed *= 0.5f; else player.speed = speed;
    }
    private void ReSpawn()
    {
        player.transform.position = spawnPoint;

    }
    private Vector3 SpawnPoint()
    {
        return player.transform.position;
    }
    

    
}
