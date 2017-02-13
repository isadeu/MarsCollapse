using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	Text timerText;
	float timeLeft = 30.0f;
	//public GameOver;
	// Use this for initialization
	void Start () {
	
		timerText = GetComponent < Text > ();

	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			Application.LoadLevel("GameOver");
			Application.Quit();


		}
		timerText.text =  "Time till imminent death: " + timeLeft.ToString ("F0") + " s";
	}
}



//gameover stuff

//// Use this for initialization
//void Start () {
//
//}
//
//// Update is called once per frame
//void Update () {
//	GameOver.SetActive = false;
//	//if 
//	//(Time stuff)
//	//  else 
//	// 	GameOver.SetActive = true;
//
//
//}
//}
