using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;
    public static float speed =2f;
    public Rigidbody rigid;
    // Use this for initialization
    public Animator anim;
    private bool isDead;
    private bool wrongplace;
    private bool getpoint;
    public static int kills = 0;
    private float distance = 20f;
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        anim = GetComponent< Animator > ();
        getpoint = false;
        isDead = false;
       
        
        wrongplace = false;
        
    }

    
    // Update is called once per frame

    private void OnTriggerEnter(Collider col)
    {
        
        if (!isDead)
        {
            if (Menu.lorr == 1)
            {
                if (col.tag == "energyr")
                {
                    
                    wrongplace = true;
                }

                if (col.tag == "energyl")
                {
                    
                    getpoint = true;
                }
            }
            else
            {
                if (col.tag == "energyr")
                {
                   
                    getpoint = true;
                }
                if (col.tag == "energyl")
                {
                    
                    wrongplace = true;
                }
            }
        }

        

        
    }
    void Update()
    {
        
        transform.position += Time.deltaTime * speed * Vector3.left;
        if (getpoint)
        {
            Menu.lorr = Random.Range(0, 2);
            isDead = true;
            
            kills++;
            getpoint = false;
            
        }
        if (wrongplace)
        {
            Menu.lorr = Random.Range(0, 2);
            isDead = true;
            
            Player.MP--;
            wrongplace = false;
            
        }
       
        if (isDead)
        {
            FindObjectOfType<audioManager>().Play("enemyDeath");
            transform.position = new Vector3(startPos.x + distance, 10.6f, startPos.z);
            rigid.velocity = new Vector3(0f, 0f, 0f);
            distance -= 10f;
            if (distance == -10f)
            {
                distance = 20f;
            }
            transform.rotation = startRot;
            speed = speed * 1.3f;
            moveLeft.speed = moveLeft.speed * 1.3f;
            
            isDead = false;
           
           
            
        }

        

        if (transform.position.x <= 0|| transform.position.y <= 0)
        {

            transform.position = new Vector3(startPos.x+25, startPos.y , startPos.z);
            rigid.velocity = new Vector3(0f, 0f, 0f);
        }

    }
}