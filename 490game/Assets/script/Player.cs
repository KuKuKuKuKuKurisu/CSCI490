using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}

    private void OnTriggerEnter(Collider col)
    {
        int getHit = 0;
        while (col.tag == "enemy")
        {
            getHit++;
            anim.Play("Damage");
            if (getHit == 5)
            {
                getHit = 0;
                anim.Play("Dead");
                break;
            }
        }
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            int action = Random.Range(0, 3);
            if (action==0)
            {
                anim.Play("Attack01");
            }
            if (action == 1)
            {
                anim.Play("Attack02");
            }
            if (action == 2)
            {
                anim.Play("Jump");
            }

        }

	}
}
