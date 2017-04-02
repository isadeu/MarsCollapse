using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endState : MonoBehaviour {
	public Texture freedomDraw;
	bool endScreen;
	public SpriteRenderer savedScreen;

	public GameObject endscreen;

	public GameObject headsetBab;
	public AudioSource headsetSource;

	// Use this for initialization
	void Start () {
		//savedScreen.color = new Color (savedScreen.color.r, savedScreen.color.g, savedScreen.color.b, 0f);
		endscreen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		
	}
	void OnTriggerEnter2D (Collider2D c){
		if (headsetBab) {
			Debug.Log ("player recieed");
			endscreen.SetActive (true);
			StartCoroutine ("Fadeout");

				//savedScreen.color = new Color (savedScreen.color.r, savedScreen.color.g,savedScreen.color.b, 0.8f);
				Time.timeScale = 0f;
				Time.fixedDeltaTime = 0f;

		} 		
	}

	IEnumerator Fadeout (){
		{ 
			headsetSource = GetComponent <AudioSource> ();

			// Check Music Volume and Fade Out
			while (headsetSource.volume > 0.01f) {
				headsetSource.volume -= Time.deltaTime / 6f;
				//Debug.Log ("headsetsource");
				yield return null;
			}
		}
	
	}

}
