using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;
	public float xOffset;
	public float yOffset;
	private bool hitGround;
	private bool hitMoving;
	private float groundY;

    public GameObject player;

    void Awake()
    {
        
		//gcamera = GameObject.Find ("Main Camera(1)");
    }

	void Update()
	{
		player = GameObject.Find("Player_Test");
		groundY = player.GetComponent<Player_Controller>().groundY;
		hitGround = player.GetComponent<Player_Controller> ().hitGround;	
		hitMoving = player.GetComponent<Player_Controller> ().hitMoving;
		//Debug.Log (hitGround + " and " + groundY);
	}

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        //transform.position = new Vector3(posX, posY, transform.position.z);
		if (!hitGround) {
			//Debug.Log ("not hit ground");
			transform.position = new Vector3 (player.transform.position.x + xOffset, /*player.transform.position.y +*/yOffset, transform.position.z);
			//GetComponent<Camera2DFollow> ().enabled = false;
			//GetComponent<CameraMovement> ().enabled = true;	
		}

		if (hitGround) {
			//Debug.Log ("Hitground");
			transform.position = new Vector3 (player.transform.position.x + xOffset, groundY + yOffset + .8f, transform.position.z);
			//GetComponent<Camera2DFollow> ().enabled = true;
			//GetComponent<CameraMovement> ().enabled = false;
		}
		/*if (player.transform.position.y > yOffset) {
			transform.position = new Vector3 (player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
		}*/
    }
		
}
