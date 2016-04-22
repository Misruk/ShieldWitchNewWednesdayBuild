using UnityEngine;
using System.Collections;

public class CameraZoomOut : MonoBehaviour {
	public Camera camcam;
	public bool zoomtime;
	// Use this for initialization
	void Start () {
		zoomtime = false;
		//camera = GameObject.Find ("Main Camera");
		//camcam = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (zoomtime) {
			camcam.orthographicSize = Mathf.Lerp (7f, 2.7f, Time.deltaTime);
			if (camcam.orthographicSize > 6.5f)
				zoomtime = false;
		}
	}

	void OnTriggerEnter2D(Collider2D hit){

		if (hit.CompareTag("Player"))
		{
			//camcam.orthographicSize = 15;
			zoomtime = true;

		}

	}
}
