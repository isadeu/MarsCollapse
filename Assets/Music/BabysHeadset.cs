using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BabysHeadset : MonoBehaviour {


	public AudioClip headsetSnd;
	public AudioSource source;
	public AudioClip cheers;

	public GameObject endscreen;

	//fade
	public float fadeTime = 1f;

	//camera
//	public screenShakeScript;

	void Awake(){
		source = GetComponent <AudioSource> ();
	}
		

	void Start(){
		//camera
	}



	void Update (){
		
		//pause volume
		if (Time.timeScale == 0f) {
			source.volume = .15f;
		} else {
			source.volume = .3f;
		}
			
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderground") {
			source.PlayOneShot (cheers, .25f);
			source.PlayOneShot (headsetSnd, .3f);
			Destroy (c.gameObject);
			 //Debug.Log ("destroyed");
		}
			
			}
		}