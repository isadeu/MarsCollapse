using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchDie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.tag == "Player")
			{
			Application.LoadLevel ("GameOver");
			Application.Quit ();
//			StartCoroutine ("Quit");
		}
	
	}
//			IEnumerator Quit (){
//				yield return new WaitForSeconds (1);
//			Application.LoadLevel ("GameOver");
//			Application.Quit ();
//				yield return 0;
//			}
}
