using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outsideSounds : MonoBehaviour {

	public AudioSource source;
	public AudioClip outside;

	void Awake(){
		source = GetComponent <AudioSource> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "colliderobjects"){
			StartCoroutine ("LetsGo");
			
			Debug.Log ("entered musicallla trigger");
//			while (source.volume > 0.01f) {
//				source.volume -= Time.deltaTime / 30f;
//			}
		}

	}

	IEnumerator LetsGo()
	{ 
		source = GetComponent <AudioSource> ();

		// Check Music Volume and Fade Out
		while (source.volume > 0.01f)
		{
			source.volume -= Time.deltaTime / 6f;
			yield return null;
		}
		source.volume = 0;
		source.Stop();
		yield return 0;
	}
			


//Application.Quit ();
//reset button and position
}
	
