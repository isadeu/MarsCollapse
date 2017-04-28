using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BabysHeadset : MonoBehaviour {


	public AudioClip headsetSnd;
	public AudioSource source;
	public AudioClip cheers;

	public GameObject endscreen;
	public BoxCollider2D colli;

	//fade
	public float fadeTime = 1f;

	//camera
//	public screenShakeScript;

	void Awake(){
		source = GetComponent <AudioSource> ();
		colli = GetComponent <BoxCollider2D> ();
		Debug.Log ("got that collider");
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
			Destroy (colli);

			//StartCoroutine ("Sec");
			//gameObject.SetActive (false);
			//Destroy (gameObject);
			//Destroy (c.gameObject);

		}
			
			}
//	IEnumerator Sec (){
//		
//		source.PlayOneShot (cheers, .25f);
//		source.PlayOneShot (headsetSnd, .3f);
//		yield return new WaitForSeconds (1);
//		gameObject.SetActive (false);
//		Debug.Log ("destroyed");
//		//Destroy (gameObject);
//		yield return 0;
//	}
		}