using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueHolder : MonoBehaviour {

	public string dialogue;
	private dialogueManager dMan;

	public string[] dialogueLines;
	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<dialogueManager> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D c)
	{
		if (c.gameObject.name == "colliderobjects") {
			if (Input.GetKeyUp(KeyCode.A)) {
				
				//dMan.ShowBox (dialogue);
				if (!dMan.dialogueActive) {
					dMan.dialogueLines = dialogueLines;
					dMan.curLine = 0;
					dMan.ShowDialogue ();
				}
			}
		}
	}
}
