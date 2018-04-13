using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 startPos;
    private Quaternion startRot;
    public Animator anim;
    public static int MP = 5;
    public static bool playerIsDead = false;
    private float verticalVelocity;
    private float gravity = 14.0f;
    private float jumpForce = 5.0f;
    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy")
        {
            anim.Play("Dead");
            FindObjectOfType<audioManager>().Play("playerDeath");
            playerIsDead = true;
        }
        if (col.tag == "deadzone")
        {

            transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
            anim.Play("Dead");
            FindObjectOfType<audioManager>().Play("playerDeath");
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



        if (MP < 0)
        {
            anim.Play("Dead");
            FindObjectOfType<audioManager>().Play("playerDeath");
            playerIsDead = true;
        }

     }
}