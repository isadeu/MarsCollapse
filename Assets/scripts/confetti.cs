using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class confetti : MonoBehaviour {


	public AudioClip cheers;
	public AudioSource source;
	//public AudioSource source;
	public ParticleSystem confettii;
	public BoxCollider2D colli;
	// Use this for initialization

	void Awake () {
		source = GetComponent <AudioSource> ();
		colli = GetComponent <BoxCollider2D> ();
		Debug.Log ("got that colldier");
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderground") {
			//Debug.Log ("confetti trigger");
			confettii.Play ();
			source.PlayOneShot (cheers, .25f);
			Destroy (colli);
			//gameObject.SetActive (false);
		}
	}
}