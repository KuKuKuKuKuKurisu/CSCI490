using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float randomOffset = 2f;
    // Use this for initialization
    public Animator anim;
    private static bool isDead = false;
    void Start()
    {
        anim = GetComponent< Animator > ();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "attack")
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.Play("Death");
                isDead = true;

            }
            if (isDead)
            {
                if (col.tag == "Player")
                {
                    float randomHeight = UnityEngine.Random.Range(0, randomOffset);
                    transform.position = new Vector3(24 + randomHeight, transform.position.y, transform.position.z);
                }
            }
        }
       
    }
    void Update()
    {
        transform.position += Time.deltaTime * speed * Vector3.left;

        if (transform.position.x <= 0)
        {
            float randomHeight = UnityEngine.Random.Range(0, randomOffset);
            transform.position = new Vector3(24 + randomHeight, transform.position.y, transform.position.z);
        }

    }
}