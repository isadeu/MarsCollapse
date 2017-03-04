using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour {

	public float startLx = .2f;
	public float startLy = .86f;
	public float endLx = -.4f;
	public float endLy = .86f;
	public float speed = .5f;
	bool moving;
	bool toMove;

	void Start(){
		moving = (true);
	}
	void Update() {

		if (moving = true) {
			Vector2 fromM = new Vector2 (startLx, startLy); //starts here
			Vector2 toM = new Vector2 (endLx, endLy); //goes to here and loops
			transform.position = Vector2.Lerp (fromM, toM, Mathf.PingPong (Time.time * speed, 2));//mlem the two is how many numbers it will be looking for (xy)
			//use bool??

		} 

	}

	void OnTriggerEnter2D (Collider2D c)
	{
		//Debug.Log ("entered trigger extra");
		moving = false; 
	}
}   