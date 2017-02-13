using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour {
	
	private Vector3 fromM = new Vector3(.2f,.86f,0); //starts here
	private Vector3 toM = new Vector3(-.4f,.86f,0); //goes to here and loops
	public float speed = .5f;

	void Start(){
	}
	void Update() {
		transform.position = Vector3.Lerp (fromM, toM, Mathf.PingPong(Time.time*speed, 3.0f));//mlem
	}
}   