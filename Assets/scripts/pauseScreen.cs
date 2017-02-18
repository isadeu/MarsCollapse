using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScreen : MonoBehaviour {
	public Texture pauseTexture;
	KeyCode pause;
	bool gamePaused = false;
	public SpriteRenderer thing;
	// Use this for initialization


	void Start () {
		pause = KeyCode.B;
	}
	
	// Update is called once per frame
	void Update () {

		//pause screen call
		if (Input.GetKeyDown (pause)) {
			gamePaused = true;
			Time.timeScale = 0f;
			Time.fixedDeltaTime = 0f;
		} 
			

		//GameObject.GetComponent <pauseScreen> ();



		if (gamePaused == false) {
			thing.color = new Color (thing.color.r, thing.color.g, thing.color.b, 0f);
			//gameObject.GetComponent<Renderer> ().material.color.a = 0;
			//	pauseTexture.color.a = 0.0f;
		}

		if (gamePaused == true) {
			thing.color = new Color (thing.color.r, thing.color.g, thing.color.b, 1f);
			//thing.color = new Color (1, 0, 0, 1); //how to choose colors for other stuff including opacity
			
		}

	}


		//reset button
			void OnGUI()
			{
				GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),pauseTexture); //button itself
				if (GUI.Button(new Rect(1000, Screen.height /2, 400, 70),"Resume")) //reset button and position
				{
					gamePaused = false;
					Time.timeScale = 1f;
					Time.fixedDeltaTime = 1f;
				}
			
		
			}
		
		}
	


