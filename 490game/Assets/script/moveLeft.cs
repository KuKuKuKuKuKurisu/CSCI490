using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour {

    public static float speed = 2f;

    private float randomOffset = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position +=Time.deltaTime * speed * Vector3.left;

        if (transform.position.x <= -25)
        {
            float randomHeight = UnityEngine.Random.Range(0, randomOffset);
            transform.position = new Vector3(50 + randomHeight, transform.position.y, transform.position.z);
        }
	}
}
