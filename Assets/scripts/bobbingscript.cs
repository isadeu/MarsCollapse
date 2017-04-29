using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobbingscript : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	//	Debug.Log ("??????");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void OnTriggerEnter2D (Collider2D c){
//		Debug.Log ("is it even here");
//		if (c.gameObject.name == "colliderground") {
//			anim.SetBool ("landed", true);

			void OnTriggerEnter2D (Collider2D col){
		//Debug.Log("c.collider.tag");
		//falling platforms 
		if (col.gameObject.name == "colliderobjects") {
			anim.SetBool ("landed", true);

		}
	}

	void OnTriggerExit2D (Collider2D col){
			//Debug.Log("c.collider.tag");
			//falling platforms 
			if (col.gameObject.name == "colliderobjects") {
				anim.SetBool ("landed", false );


	//	else {
			//anim.SetBool ("landed", false);
		}
	}
}
