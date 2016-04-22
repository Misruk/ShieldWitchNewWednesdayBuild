using UnityEngine;
using System.Collections;

public class InitiateEnd : MonoBehaviour {

	private GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.Find ("Player_Test");
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Deadly")
		{
			player.GetComponent<Player_Controller> ().winner = true;
		}
	}
}
