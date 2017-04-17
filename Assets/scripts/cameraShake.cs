using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour {

	Vector3 weightedDirection;
	Vector3 defaultCameraPos; //have it updated to where the camera is moving 
	float screenShakeTimer = 0;
	float thisMagnitude = 0;

	// Use this for initialization
	void Start () {
		defaultCameraPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (screenShakeTimer > 0){
			Vector3 shakeDirection = ((Vector3) Random.insideUnitCircle +weightedDirection).normalized * thisMagnitude * Mathf.Clamp01(screenShakeTimer);
			Vector3 result = defaultCameraPos + shakeDirection;
			result.z = -10f;
			transform.position = result;
			//transform.position = defaultCameraPos + shakeDirection;
			screenShakeTimer -= Time.deltaTime;
		}
	}


	public void SetScreenshake(float magnitude,float duration, Vector3 direction){
		weightedDirection = direction; 
		thisMagnitude = magnitude;
		screenShakeTimer = duration;
	}

	public void SetScreenshake (float magnitude, float duration){
		SetScreenshake (magnitude, duration, Vector3.zero);
	}
}
