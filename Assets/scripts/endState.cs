using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endState : MonoBehaviour {
	public Texture freedomDraw;
	bool endScreen;
	public SpriteRenderer savedScreen;

	public GameObject headsetBab;
	public AudioSource headsetSource;

	// Use this for initialization
	void Start () {
		//headsetSource = GetComponent <AudioSource> ();

		savedScreen.color = new Color (savedScreen.color.r, savedScreen.color.g, savedScreen.color.b, 0f);
	}
	
	// Update is called once per frame
	void Update () {

		
	}
	void OnTriggerEnter2D (Collider2D c){
		if (headsetBab) {
			Debug.Log ("player recieed");
	//	StartCoroutine ("AudioFadeOut");

				savedScreen.color = new Color (savedScreen.color.r, savedScreen.color.g,savedScreen.color.b, 0.8f);
				Time.timeScale = 0f;
				Time.fixedDeltaTime = 0f;

		} 		
	}

	//i rlly did try btut like no
//	IEnumerator AudioFadeOut (){
//		Debug.Log ("audiofadeout ienumerator");
//		headsetSource = GetComponent <AudioSource> ();
//		// Check Music Volume and Fade Out
//		if (headsetSource.isPlaying) {
//			Debug.Log ("if headset is playing");
//			while (headsetSource.volume > 0.01f) {
//				headsetSource.volume -= Time.deltaTime / 20f;
//				yield return null;
//			}
//			headsetSource.volume = 0;
//			headsetSource.Stop ();
//			yield return 0;
//		}
//	}

}
