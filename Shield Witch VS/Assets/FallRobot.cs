using UnityEngine;
using System.Collections;

public class FallRobot : MonoBehaviour {

	public GameObject lefteye;
	public GameObject righteye;
	public bool passbridge;
	public bool isdeadL;
	public bool isdeadR;
	public GameObject bridge2;
	// Use this for initialization
	void Start () {
		bridge2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		isdeadL = lefteye.GetComponent<EnemyShooter> ().isdead;
		isdeadR = righteye.GetComponent<EnemyShooter> ().isdead;

		if (isdeadL && isdeadR) {
			bridge2.SetActive (true);
			gameObject.AddComponent<Rigidbody2D> ().gravityScale = .5f;
		}
	}


}
