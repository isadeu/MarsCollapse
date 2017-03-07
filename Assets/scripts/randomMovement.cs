using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMovement : MonoBehaviour {
	Rigidbody2D rb;
	var stuff = Transform;
	var  vel = Vector2; // hold random velocity
	float switchDirection = 3;
	float curTime  = 0;
	void Start (){
		rb = GetComponent <Rigidbody2D> ();

		SetVel ();
	}

	void SetVel ()
	{
		if (Random.value > .5) {
			vel = 10 * 10 * Random.value;
		} else {
			vel = -10 * 10 * Random.value;
		}
	}

	// Update is called once per frame
	void Update () {
		if (curTime < switchDirection) {
			curTime += 1 * Time.deltaTime;  //0.01666667
		}
		else{v
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
	stuff.rb.velocity = vel;
	}

}