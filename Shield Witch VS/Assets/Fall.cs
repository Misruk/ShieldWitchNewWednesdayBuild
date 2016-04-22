using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

	public GameObject boss;
	//private float trans;
	public bool falling = false;
	private GameObject player;
	public GameObject portal;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player_Test");
		//portal = GameObject.Find ("Portal"); 	
		//trans = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (boss.GetComponent<Enemy> ().isdead == true) {
			player.GetComponent<Player_Controller> ().winner = true;
			falling = true;
			gameObject.AddComponent<Rigidbody2D> ();
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = .25f;
			portal.SetActive (true);
			//portal.GetComponent<Glow>().StartCoroutine(

		}
	}


}
