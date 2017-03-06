using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMovement : MonoBehaviour {
	public GameObject critter;

	//float toEnd = 10f;
	float speed = 1f;
	//float posX = -4.5f;
	float velocity= 1f; 


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

//			if (Random.value > .5) {
//				critter.velocity = 10 * 10 * Random.value;
//			} else {
//				critter.speed = -10 * 10 * Random.value;
//			}
//			if (Random.value > .5) {
//				critter.velocity.z = 10 * 10 * Random.value;
//			} else {
//				critter.velocity.z = -10 * 10 * Random.value;
//			}
	}
//

		//-----------------
//		float speed = 1f;
//		float posX = -4.5f;
//		float toEnd = Random.Range (6f, 3f);
//		
//			Vector3 pos = new Vector3 ( posX+Mathf.PingPong (speed * Time.time, toEnd),0, 0);
//			transform.position = pos;
//		}
		

//	   -----
		
		//transform.position = Vector3(Mathf.PingPong(Time.time*3,9.9)-4.9,Mathf.PingPong(Time.time*3,7.1)-3.6,0);
		//--
//		float xX = Random.Range (-4.8f, -4f);
//		float xXX = Random.Range (-4f, -3f);
//		float speed = Random.Range (.11111f, .3f);
//		Vector2 fromM = new Vector2 (xX, 0.23f); //starts here
//		Vector2 toM = new Vector2 (xXX, 0.23f); //goes to here and loops
//		transform.position = Vector2.Lerp (fromM, toM, Mathf.PingPong (speed, 2));
	
}
	