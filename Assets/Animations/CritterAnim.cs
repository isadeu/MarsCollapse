using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterAnim : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	}

	
	// Update is called once per frame
	void Update () {
		float direction = transform.position.x;
		anim.SetFloat ("Speed", direction);

	}
}
