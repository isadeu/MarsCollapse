using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flys : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Random.insideUnitSphere * 2;//randomly move/appear within a 3 point ¡radius 
		
	}
}
