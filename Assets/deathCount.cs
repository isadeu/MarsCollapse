using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathCount : MonoBehaviour {
	
	// Use this for initialization
	float peopleSaved = 0f;
	Text deathcountText;



	void Start () {
		deathcountText = GetComponent < Text > ();

	}



	// Update is called once per frame
	void Update () {
			deathcountText.text = "Miners saved: " + peopleSaved.ToString ("F0") + " out of 5";
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "following") {
			peopleSaved += 1f;
		}
		
	}

}