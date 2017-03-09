using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class randomMovement : MonoBehaviour {
	Rigidbody2D rb;
	Transform stuff;
	Vector2 vel; // hold random velocity
	float switchDirection =3; //3
	float curTime  = 2;

	void Start (){
		rb = GetComponent <Rigidbody2D> ();
		SetVel ();
		transform.rotation = Quaternion.identity;
	}
	void SetVel ()
	//give switchdirection within the velocity
	//if not addfoce in negatives 
	{
		if (Random.value > 0.5f) {
			vel = Vector2.right * Random.Range(1,5); //1-5
		}
		else {
			vel = Vector2.left * Random.Range(1,5);
		}
	}
	// Update is called once per frame
	void Update () {
		if (curTime < switchDirection) {
			curTime += 1f * Time.deltaTime;  //0.01666667
		}
		else{
			SetVel ();
			if (Random.value > .5) {
				switchDirection += Random.value;
			}
			else {
				switchDirection -= Random.value;
			}
		}
		if (switchDirection < 1) {
			switchDirection = 1 + Random.value;
		}
		curTime = 0;
	}
	void FixedUpdate ()
	{
		rb.velocity = vel;
	}
}
	