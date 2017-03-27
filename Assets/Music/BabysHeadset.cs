using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BabysHeadset : MonoBehaviour {


	public AudioClip headsetSnd;
	public AudioSource source;

	void Awake(){
		source = GetComponent <AudioSource> ();
	}
		

	void Update (){

		if (Time.timeScale == 0f) {
			source.volume = .3f;
		} else {
			source.volume = 1f;
		}
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderground"){
			Debug.Log ("music collider");
			source.PlayOneShot (headsetSnd, 1f);
			Destroy (c.gameObject);
			Debug.Log ("destroyed");
	}
	}
		
}
	