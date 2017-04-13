using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	Text timerText;
	float timeLeft = 10000.0f;
	// Use this for initialization
	float speed = 2.0f;



	void Start () {
		timerText = GetComponent < Text > ();

	}


	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			SceneManager.LoadScene ("GameOver");
			//Application.Quit ();
		}

		timerText.text = "Time till imminent death: " + timeLeft.ToString ("F0") + " s";
		if (timeLeft < 10) {
			if (Mathf.Round (timeLeft * 5) % 2 == 0) { //% makes it loop
				timerText.color = Color.red;
				timerText.fontSize = 25;
			} else 

				timerText.color = Color.white;
		
			//timerText.color = Color.red;
			//timerText.color = Mathf.Round(Mathf.PingPong(Time.time * speed, 1.0));
			//redText = (true);
		}
				
	}
}