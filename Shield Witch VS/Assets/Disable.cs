using UnityEngine;
using System.Collections;

public class Disable : MonoBehaviour {
	public GameObject spider1;
	public GameObject spider2;
	public GameObject spider3;

	public bool s1dead;
	public bool s2dead;
	public bool s3dead;

	private AudioSource[] allAudioSources;
	private AudioSource rockSource;
	public AudioClip rocksound;

	private Collider2D col;
	private Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
		col = GetComponent<BoxCollider2D> ();
		rigid = GetComponent<Rigidbody2D> ();
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		rockSource = allAudioSources [0];
	}
	
	// Update is called once per frame
	void Update () {
		s1dead = spider1.GetComponent<EnemyShooter> ().isdead;
		s2dead = spider2.GetComponent<EnemyShooter> ().isdead;
		s3dead = spider3.GetComponent<EnemyShooter> ().isdead;

		if (s1dead && s2dead && s3dead) {
			StartCoroutine (FlyAway ());
		}
	}

	IEnumerator FlyAway(){
		yield return new WaitForSeconds (1.0f);
		rockSource.clip = rocksound;
		rockSource.Play ();
		col.isTrigger = true;
		rigid.isKinematic = false;

	}
}
