using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	public bool dialogueActive;
	public string [] dialogueLines;
	public int curLine;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueActive && Input.GetKeyDown(KeyCode.A)){
			curLine++;
		}

		if (curLine >= dialogueLines.Length) {
			dBox.SetActive (false);
			dialogueActive = false;

			curLine = 0;
		}

		dText.text = dialogueLines [curLine];
		
	}

	public void ShowBox (string dialogue){

		dialogueActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;
	}

	public void ShowDialogue (){
		dialogueActive = true;
		dBox.SetActive (true);

	}
}
