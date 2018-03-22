using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;

    public Animator anim;
    public static int MP = 5;
    public static bool playerIsDead = false;
    private float verticalVelocity;
    private float gravity = 14.0f;
    private float jumpForce = 5.0f;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy" && MP >= 0&& !enemyScript.dead)
        {
            anim.Play("Dead");
            playerIsDead = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.Play("Jump");
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
    
        if (Input.GetMouseButtonDown(0))
        {
            MP--;
            int action = Random.Range(0, 2);
            if (action == 0)
            {
                anim.Play("Attack01");
            }
            if (action == 1)
            {
                anim.Play("Attack02");
            }
            
        }

        

        if (Player.playerIsDead || Player.MP <= 0)
        {
            anim.Play("Dead");
        }

    }
}