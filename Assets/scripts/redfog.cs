using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redfog : MonoBehaviour {

	public bool fogOn;
	public SpriteRenderer foggy;

	// Use this for initialization
	void Start () {
		//fogOn = false;
		
	}

	// Update is called once per frame


	void Update () {
		if (Random.value > .6) {
			fogOn = true;
		} else {
			fogOn = false; 
//		}
//
//		if (Random.value < .5) {
//			fogOn = false;
		}

	if (fogOn == true ){	
			foggy.color = new Color (foggy.color.r, foggy.color.g,foggy.color.b, 1f);
	}
		if (fogOn == false) {
			foggy.color = new Color (foggy.color.r, foggy.color.g,foggy.color.b, 0f);
		}
	}


}
