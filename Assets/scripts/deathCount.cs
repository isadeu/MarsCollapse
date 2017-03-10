using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathCount : MonoBehaviour {
	
	// Use this for initialization
	public int peopleSaved = 0;
	public Text deathcountText;



	void Start () {
		//deathcountText = GetComponent < Text > ();

	}



	// Update is called once per frame
	void Update () {
		deathcountText.text = "Miners saved: "+ peopleSaved + " out of 5";
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "NPCs") {
			Debug.Log ("triggered");
			peopleSaved += 1;
			c.gameObject.SetActive (false);
		}
		
	}

}