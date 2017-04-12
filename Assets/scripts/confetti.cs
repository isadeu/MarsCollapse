using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confetti : MonoBehaviour {


	public ParticleSystem confettii;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderobjects")
			Debug.Log ("confetti trigger");
			confettii.Play ();
			gameObject.SetActive (false);
		}
	}
