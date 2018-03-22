using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyBar : MonoBehaviour {
    public Slider mpBar;
	// Use this for initialization
	void Start () {
        mpBar.value = 5;
	}
	
	// Update is called once per frame
	void Update () {
        mpBar.value = Player.MP;
	}
}
