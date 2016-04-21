using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
	private bool hitGround;
	private bool hitMoving;

	public GameObject player;
	public CameraMovement smoothcam;
	public Camera2DFollow strictcam;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player_Test");
	}
	
	// Update is called once per frame
	void Update () {
		hitGround = player.GetComponent<Player_Controller> ().hitGround;
		hitMoving = player.GetComponent<Player_Controller> ().hitMoving;

		if (hitGround) {
			smoothcam.enabled = true;
			strictcam.enabled = false;
			player.GetComponent<Rigidbody2D> ().gravityScale = 3;
		}

		if (hitMoving) {
			smoothcam.enabled = false;
			strictcam.enabled = true;
			//player.GetComponent<Rigidbody2D>().gravityScale = 
		}
	}
}
