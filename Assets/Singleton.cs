using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// C#
public class Global: MonoBehaviourSingleton <Global> {

	private static Global me;
	public int socks = 3;

	private void Awake()
	{
		me = this;
	}

	void Start(){
	}
	//	void FixedUpdate(){
	//		if (Global.me . socks >2

	void Update(){
	}

}
