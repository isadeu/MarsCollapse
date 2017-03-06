using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcText : MonoBehaviour {

	public GameObject textStuff;
	TextMesh npcsText;

	// Use this for initialization
	void Start () {
		textStuff.SetActive (false);
		npcsText = textStuff.GetComponent<TextMesh> ();
		npcsText.text = "Hello? Anybody there?";

	}

	// Update is called once per frame
	void Update () {

	}
	public void PlayerCancel () {
		textStuff.SetActive (false);
	}

	public void TalkToPlayer () {
		textStuff.SetActive (true);
		// SET TEXT HERE
		//as an array
	}
}