using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlat : MonoBehaviour {
	Rigidbody2D rb;
	public float fallDelay;
	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

		void OnTriggerEnter2D (Collider2D c){
		//falling platforms 
		if (c.gameObject.tag == "Player") {
			StartCoroutine (Fall ());
		}
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds (fallDelay);
		rb.isKinematic = false;
		Debug.Log ("kinematicy");

		yield return 0;

	}
}
