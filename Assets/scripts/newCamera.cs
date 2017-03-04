using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCamera : MonoBehaviour {
	private Vector2 velocity;
	public float smoothTimeY;
	public float smoothTimeX;
	public GameObject mainChara;

	void Start () {
		//mainChara = GameObject.FindGameObjectsWithTag ("Player");

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate (){
		//not rough
		float posX = Mathf.SmoothDamp(transform.position.x, mainChara.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, mainChara.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);

	}
}
	
