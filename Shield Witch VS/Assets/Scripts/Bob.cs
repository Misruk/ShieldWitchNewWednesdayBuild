using UnityEngine;
using System;
using System.Collections;

public class Bob : MonoBehaviour
{
	float originalY;
	public float floatStrength = 1;
	// You can change this in the Unity Editor to 
	// change the range of y positions that are possible.

	void Start()
	{

		originalY = this.transform.position.y;
	}

	void FixedUpdate()
	{
		this.transform.position = new Vector3(this.transform.position.x,
			originalY + ((float)Math.Sin(Time.time) * floatStrength),
			this.transform.position.z);
		
	}


}