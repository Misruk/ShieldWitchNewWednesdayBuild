using UnityEngine;
using System.Collections;

public class CameraZoomOut : MonoBehaviour {
	public Camera camcam;
	public bool zoomtime;
	public float amount;
	// Use this for initialization
	void Start () {
		zoomtime = false;
		//camera = GameObject.Find ("Main Camera");
		//camcam = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (zoomtime) {
			camcam.orthographicSize = Mathf.Lerp (amount, 2.7f, Time.deltaTime);
			//if (camcam.orthographicSize > 6.5f)
				//zoomtime = false;
		}

		if (!zoomtime) {
			camcam.orthographicSize = 2.7f;
		}
	}

	void OnTriggerEnter2D(Collider2D hit){

		if (hit.CompareTag("Player"))
		{
			//camcam.orthographicSize = 15;
			zoomtime = true;
		}

	}

	void OnTriggerExit2D(Collider2D hit){

		if (hit.CompareTag ("Player")) {
			zoomtime = false;
		}
	}
}
