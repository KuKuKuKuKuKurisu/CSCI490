using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float randomOffset = 3f;
    // Use this for initialization
    public Animator anim;
    private bool isDead;
    private bool at;
    public static bool dead;
    void Start()
    {
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
            Player.MP++;
            float randomHeight = UnityEngine.Random.Range(0, randomOffset);
            transform.position = new Vector3(35 + randomHeight, transform.position.y, transform.position.z);
            isDead = false;
            at = false;
            dead = false;
        }

        if (transform.position.x <= 0)
        {
            float randomHeight = UnityEngine.Random.Range(0, randomOffset);
            transform.position = new Vector3(35 + randomHeight, transform.position.y, transform.position.z);
        }

    }
}