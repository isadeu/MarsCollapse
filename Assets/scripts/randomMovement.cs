using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class randomMovement : MonoBehaviour {
	Rigidbody2D rb;
	Transform stuff;
	Vector2 vel; // hold random velocity
	//float switchDirection =3; //3
	float switchDirection = 1;
	float curTime = 0;
	//boundaries 
	public float leftBound = -4.7f;
	public float rightBound = 0.28f;
	//GameObject critter;
	public float endLx = -1.899f;
	public float endLy = 0.16f;
	Vector2 playerPosition;


	void Start (){
		rb = GetComponent <Rigidbody2D> ();
		SetVel ();

	}

	void SetVel ()
	//give switchdirection within the velocity
	//if not addfoce in negatives 
	{
		if (Random.value > 0.5f) {
			vel = Vector2.right * Random.Range(0, 1f); //2if random num is biger than .5 go right (speed determined by 1-5)
		} else {
			vel = Vector2.left * Random.Range(0, 1f);//2if it is not go left and hwo far
		}
	}
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;

		if (curTime < switchDirection) { 
			curTime += 1f * Time.deltaTime;  //0.01666667
		} else {
			SetVel ();
			if (Random.value > .5) {
				switchDirection = Random.value;
			} else {
				switchDirection = Random.value;
			}
			//}
			if (switchDirection < 1) {
				switchDirection = 1 + Random.value;
				curTime = 0;
			}
		}

		//boundaries

		playerPosition = transform.position;
		Vector2 targetPosition = new Vector2 (endLx, endLy);

		if (transform.position.x < leftBound) {
			StartCoroutine ("TurnRight");
		}


		if (transform.position.x > rightBound) {
			StartCoroutine ("TurnLeft");
		}
	}

	IEnumerator TurnRight (){
		yield return new WaitForSeconds (1);
		playerPosition = transform.position;
		Vector2 targetPosition = new Vector2 (endLx, endLy);
		Vector2.MoveTowards(playerPosition, targetPosition, 2f);
		Debug.Log ("should turn right now");
		yield return 0;
	}
	IEnumerator TurnLeft (){
		yield return new WaitForSeconds (1);
		playerPosition = transform.position;
		Vector2 targetPosition = new Vector2 (endLx, endLy);
		Vector2.MoveTowards (playerPosition, targetPosition, 2f);
		Debug.Log ("should turn left now");
	}

		//doesnt work either tbh who knows
//		Vector2 toM = new Vector2 (endLx, endLy); //goes to here and loops
//		playerPosition = transform.position;
//	
//		 
//		if (transform.position.x < leftBound) {
//			//Debug.Log("if position is smaller than left turn around");
//			Vector2.Lerp (playerPosition, toM, Mathf.PingPong (Time.time * 1, 2));
//
//		}



		//doesnt work, simply chnages direction does not return to original position
//		if (transform.position.x < leftBound) {
//			switchDirection = Random.value;
//			Debug.Log("leftbound");
//		}
//		if (transform.position.x > rightBound) {
//			Debug.Log("rightbound");
//			switchDirection = Random.value;
//		}
			
	



	void FixedUpdate (){
		rb.velocity = vel;
	}
}
	