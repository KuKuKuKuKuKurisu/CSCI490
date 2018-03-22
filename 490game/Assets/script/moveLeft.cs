using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour {
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float randomOffset = 2f;
    public static float speedlevel = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position +=Time.deltaTime * speed * Vector3.left*speedlevel;

        if (transform.position.x <= -25)
        {
            float randomHeight = UnityEngine.Random.Range(0, randomOffset);
            transform.position = new Vector3(50 + randomHeight, transform.position.y, transform.position.z);
        }
	}
}
