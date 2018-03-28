﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private Vector3 startPos;

    public static float speed =2f;

    // Use this for initialization
    public Animator anim;
    private bool isDead;
    private bool at;
    public static bool dead;
    public static int kills = 0;
    void Start()
    {
        startPos = transform.position;
        anim = GetComponent< Animator > ();
        isDead = false;
        at = false;
        dead = false;
        
    }

    private void Dead()
    {
        if (isDead)
        {
            dead = true;
        }
        else
        {
            dead = false;
        }
    }
    // Update is called once per frame

    private void OnTriggerEnter(Collider col)
    {
        if (!isDead)
        {
            if (col.tag == "attack")
            {
                at = true;
               
            }
        }
           
    }
    void Update()
    {
        
        transform.position += Time.deltaTime * speed * Vector3.left;

        if (Input.GetMouseButtonDown(0)&&at)
        {
            isDead = true;
        }
        Dead();
        if (isDead)
        {
            anim.Play("Death");
            if (Player.MP == 4)
            {
                Player.MP = Player.MP + 1;
                
            }
            else if(Player.MP < 4)
            {
                Player.MP = Player.MP + 2;
                
            }
            
            transform.position = new Vector3(startPos.x + 25, startPos.y, startPos.z);
            speed = speed * 1.1f;
            moveLeft.speed = moveLeft.speed*1.1f;
            kills++;
            isDead = false;
            at = false;
            dead = false;
            
        }
       
        if (transform.position.x <= 0|| transform.position.y <= 0)
        {

            transform.position = new Vector3(startPos.x+25, startPos.y , startPos.z);
        }

    }
}