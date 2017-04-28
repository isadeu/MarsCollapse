using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheers : MonoBehaviour {


	public AudioSource source;
	public AudioClip yay;

	// Use this for initialization
	void Start () {
		source = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderground") {
			source.PlayOneShot (yay, .25f);
			Debug.Log ("it played");
			//Destroy (c.gameObject);
		}
		}
}
