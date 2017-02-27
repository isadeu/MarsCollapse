using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMovement : MonoBehaviour {
	//public GameObject critter; 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.position = Vector3(Mathf.PingPong(Time.time*3,9.9)-4.9,Mathf.PingPong(Time.time*3,7.1)-3.6,0);
		float xX = Random.Range (-4.8f, -4f);
		float xXX = Random.Range (-4f, -3f);
		float speed = Random.Range (.11111f, .3f);
		Vector2 fromM = new Vector2 (xX, 0.23f); //starts here
		Vector2 toM = new Vector2 (xXX, 0.23f); //goes to here and loops
		transform.position = Vector2.Lerp (fromM, toM, Mathf.PingPong (Time.deltaTime * speed, 2));

		//Vector3 position = new Vector3(Random.Range(-4.8f, -3f), 0.23f,0f);
		//Instantiate(critter,position, Quaternion.identity);
	}
	
}

