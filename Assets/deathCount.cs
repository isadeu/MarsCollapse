using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathCount : MonoBehaviour {
	
	//float timeLeft = 20.0f;
	// Use this for initialization
	//float speed = 2.0f;
	float peopleSaved = 0f;
	Text deathcountText;



	void Start () {
		deathcountText = GetComponent < Text > ();

	}



	// Update is called once per frame
	void Update () {

		deathcountText.text = "Those who you have Saved: " + peopleSaved.ToString ("F0") + " s";
		
		}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "following") {
			peopleSaved += 1f;
		}
		
	}

}