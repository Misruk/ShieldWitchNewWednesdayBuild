using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;
	// Use this for initialization
	void Start () {
		currentPoint = points [pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

		if(platform.transform.position == currentPoint.position)
		{
			pointSelection++;

			if (pointSelection == points.Length)
			{
				pointSelection = 0;
			}

			currentPoint = points [pointSelection];
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Wall") {
			Debug.Log ("hit wall");
			moveSpeed = 0;
		}

		if (col.gameObject.tag == "Player") {
			moveSpeed = 2;
		}
	}
}
