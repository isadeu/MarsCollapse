using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endState : MonoBehaviour {
	public Texture freedomDraw;
	bool endScreen;
	public SpriteRenderer savedScreen;

	public GameObject headsetBab;

	// Use this for initialization
	void Start () {

		savedScreen.color = new Color (savedScreen.color.r, savedScreen.color.g, savedScreen.color.b, 0f);
	}
	
	// Update is called once per frame
	void Update () {

		
	}
	void OnTriggerEnter2D (Collider2D c){
		if (headsetBab) {
			Debug.Log ("player recieed");
			//endScreen = true;
			//if (endScreen == true) {
				savedScreen.color = new Color (savedScreen.color.r, savedScreen.color.g,savedScreen.color.b, 0.8f);
				Time.timeScale = 0f;
				Time.fixedDeltaTime = 0f;

		} 		
	}
}
