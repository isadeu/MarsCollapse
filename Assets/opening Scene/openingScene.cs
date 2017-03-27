using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class openingScene : MonoBehaviour {

	public Texture openingTexture; 

	//sound
	public AudioClip introSing;
	public AudioSource source;
	public float fadeTime = 5f;

	void Awake(){
		source = GetComponent <AudioSource> ();
	}
		
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), openingTexture); //button itself
		if (GUI.Button (new Rect (1000, Screen.height / 2, 400, 70), "Beguin!"))
			StartCoroutine ("LetsGo");

			
		//Application.Quit ();
			//reset button and position
		}
	IEnumerator LetsGo()
	{ 
		source = GetComponent <AudioSource> ();

			// Check Music Volume and Fade Out
			while (source.volume > 0.01f)
			{
				source.volume -= Time.deltaTime / 20f;
				yield return null;
			}
		SceneManager.LoadScene ("modelPlatformer");  //click button = go to intro scene
		source.volume = 0;
		source.Stop();
		yield return 0;
	}
}
	