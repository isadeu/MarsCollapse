using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platMusic : MonoBehaviour {

	public AudioClip crumble;
	public AudioSource source;
	// Use this for initialization


	void Awake (){

		source= GetComponent <AudioSource> ();
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D c){
		//falling platforms 
		if (c.gameObject.name == "colliderobjects") {
			source.PlayOneShot (crumble, 1f);
			Destroy (c);
		}
	}
}
