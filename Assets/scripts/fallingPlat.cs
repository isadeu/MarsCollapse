﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlat : MonoBehaviour {
	Rigidbody2D rb;
	public float fallDelay;
	public float dissapearTime;
	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	}


		void OnTriggerEnter2D (Collider2D c){
		Debug.Log("c.collider.tag");
		//falling platforms 
		if (c.gameObject.name == "colliderobjects") {
			StartCoroutine ("Fall");
		}
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds (fallDelay);
		rb.isKinematic = false;
		yield return new WaitForSeconds(dissapearTime);
		gameObject.active = false;
		yield return 0;



	}
}
