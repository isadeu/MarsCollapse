using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterCave : MonoBehaviour {


	public AudioClip cavesounds;
	public AudioSource source;

	//fade
	public float fadeTime = 1f;

	void Awake(){
		source = GetComponent <AudioSource> ();
	}


	void Start(){
	}


	void Update (){

		//pause volume
		if (Time.timeScale == 0f) {
			source.volume = .15f;
		} else {
			source.volume = .2f;
		}

	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderground") {
			source.Pause ();
			source.PlayOneShot (cavesounds, .2f);
			c.isTrigger = true;
			Destroy (c.gameObject);
			//Debug.Log ("destroyed");
		}
	}
}