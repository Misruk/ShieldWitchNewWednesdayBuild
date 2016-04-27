﻿using UnityEngine;
using System.Collections;

public class MoveBridge : MonoBehaviour {

	public float max;//end x position
	public float maxr;// angle of rotation
	public float maxy;//end y position
	public float maxz;//end z position
	public float rate;
	public bool inRange;
	public bool open;
	public bool clickable;
	private GameObject rock;
	public bool grounded;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.Lerp (transform.position.x, max, Time.deltaTime * rate), Mathf.Lerp (transform.position.y, maxy, Time.deltaTime * rate), Mathf.Lerp (transform.position.z, maxz, Time.deltaTime * rate));
	}
}
