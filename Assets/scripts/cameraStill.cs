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

/*
public GameObject player;

// Use this for initialization
void Start () {

}

// Update is called once per frame
void Update () {
	transform.position = new Vector2.Lerp (player.transform.position, 2f * Time.deltaTime);
	transform.position = new Vector3 (transform.position.x, transform.position.y, -10);
}
}
*/