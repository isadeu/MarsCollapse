using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScreen : MonoBehaviour {
	public Texture pauseTexture; //this cant be a texture 
	KeyCode pause;
	bool gamePaused = false;
	public SpriteRenderer pScreen;
	// Use this for initialization


	void Start () {
		pause = KeyCode.P;
	}
	
	// Update is called once per frame
	void Update () {

		//pauses time
		if (Input.GetKeyDown (pause)) {
			gamePaused = true;
			Time.timeScale = 0f;
			Time.fixedDeltaTime = 0f;
		} 


		//image on the screen when paused
		if (gamePaused == false) {
			pScreen.color = new Color (pScreen.color.r, pScreen.color.g, pScreen.color.b, 0f);
		}

		if (gamePaused == true) {
			pScreen.color = new Color (pScreen.color.r, pScreen.color.g,pScreen.color.b, 0.8f);
			//thing.color = new Color (1, 0, 0, 1); //how to choose colors for other stuff including opacity
		}

	}


		//resume button
			void OnGUI()
			{
		if (gamePaused == true) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), pauseTexture); //button itself
			if (GUI.Button (new Rect (1000, Screen.height / 2, 400, 70), "Resume")) { //reset button and position
				gamePaused = false;
				Time.timeScale = 1f;
				Time.fixedDeltaTime = 0.01666667f;
				//just hrd code button
			}
		}
		
			}
		
		}
	


