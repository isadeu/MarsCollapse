using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openingScene : MonoBehaviour {
	public Texture openingTexture; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), openingTexture); //button itself
		if (GUI.Button (new Rect (1000, Screen.height / 2, 400, 70), "Beguin!")) { 
			Application.LoadLevel ("modelPlatformer");  //click button = go to intro scene
			Application.Quit ();
			//reset button and position
		}
	}
}
