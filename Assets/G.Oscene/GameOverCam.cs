using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public Texture gameOverTexture;

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),gameOverTexture); //button itself
		if (GUI.Button(new Rect(1000, Screen.height /2, 400, 70),"Try again")) //reset button and position
		{
			SceneManager.LoadScene("modelPlatformer");  //click button = go to intro scene
			//Application.Quit();
		}


	}

}
