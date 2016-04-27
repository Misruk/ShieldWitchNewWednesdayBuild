using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
	private bool hitGround;
	private bool hitMoving;

	public GameObject player;
	public CameraMovement smoothcam;
	public Camera2DFollow strictcam;
	public GameObject player2;
	// Use this for initialization
	void Start () {
		if(MenuManager.characterSelected == 0)
		{
			Debug.Log("Camera locked onto Witch");
		} else if (MenuManager.characterSelected == 1)
		{
			player = player2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//player = GameObject.Find("Player_Test");
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
