using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverCam : MonoBehaviour {



	public AudioClip gosong;
	public AudioSource source;
	public float fadeTime = 5f;


	void Awake(){
//		source = GetComponent <AudioSource> ();
//
//		while (source.volume < .1f) {
//		source.volume += Time.deltaTime / 20f;
//					}

	}

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
			StartCoroutine ("LetsGo");

	}
		

	IEnumerator LetsGo()
	{ 
		source = GetComponent <AudioSource> ();

		// Check Music Volume and Fade Out
		while (source.volume > 0.01f)
		{
			source.volume -= Time.deltaTime / 10f;
			yield return null;
		}
		SceneManager.LoadScene ("modelPlatformer");  //click button = go to intro scene
		source.volume = 0;
		source.Stop();
		yield return 0;
	
			SceneManager.LoadScene("modelPlatformer");  //click button = go to intro scene
			//Application.Quit();
	}

}
