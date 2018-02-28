using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator anim;
    public static int MP = 5;
    public static bool playerIsDead = false;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }



    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy" && MP >= 0)
        {
            anim.Play("Dead");
            playerIsDead = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MP--;
            int action = Random.Range(0, 3);
            if (action == 0)
            {
                anim.Play("Attack01");
            }
            if (action == 1)
            {
                anim.Play("Attack02");
            }
            //  if (action == 2)
            // {
            //   anim.Play("Jump");
            //  }

        }

        if (Input.GetKeyDown("space"))
        {
            anim.Play("Jump");
        }

        if (Player.playerIsDead || Player.MP < 0)
        {
            anim.Play("Dead");
        }

    }
}