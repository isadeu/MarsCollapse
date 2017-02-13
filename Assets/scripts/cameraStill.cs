using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraStill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;//so the obejct doesn't tilt	
		
	}
}
