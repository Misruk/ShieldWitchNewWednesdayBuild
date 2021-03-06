﻿using UnityEngine;
using System.Collections;

public class EnemyStraightShooter : MonoBehaviour {
	public int enHealth = 2;
	public int speed;
	private Vector3 euler;
	private Vector3 look;
	private Transform target;
	public bool inRange = true;
	public GameObject bulletPrefab;
	public float shootDelay;
	public GameObject bulletSpawner;
	public bool dead;

	private Animator anim;

	//Enemy Shooter Audio
	public AudioClip shooterdeath;
	private AudioSource shooterdeathSource;
	public AudioClip shooterfire;
	private AudioSource shooterfireSource;
	public AudioClip shooterdamage;
	private AudioSource shooterdamageSource;

	public GameObject[] explosions;
	public Color[] colors;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		//target = GameObject.FindGameObjectWithTag("Player").transform;
		target = GameObject.Find("Player_Test").transform;
		InvokeRepeating("Shoot", 1f, shootDelay);
		//ShooterAudio
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		shooterdeathSource = allAudioSources [0];
		shooterfireSource = allAudioSources [1];
		shooterdamageSource = allAudioSources [2];
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (dead) {
			//GetComponent<Animator>().
		}
		//euler = transform.eulerAngles;
		// look = target.transform.position - this.transform.position;
		//euler.z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
		// transform.eulerAngles = euler;

		/* if (!inRange)
         {
             //this.transform.position += look.normalized * speed * Time.deltaTime;
         }*/

		if (!inRange)
		{
			//anim.SetBool("Sighted", false);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "BulletHold" || col.gameObject.tag == "Deadly" && enHealth > 0)
		{
			//target.GetComponent<Rescue>().addScoreEnemy(100);
			//Destroy(this.gameObject);
			StartCoroutine(Damage());
			//StartCoroutine (OnDeath ());
		}
		else if (enHealth < 1) {
			StartCoroutine (OnDeath ());
			dead = true;
		}


		/*if(col.gameObject.tag == "Player")
		{
			Debug.Log("Player in range of trigger");
			inRange = true;
		}*/

	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Debug.Log("Player in range of trigger");
			//inRange = true;
		}

	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player")
		{
			//Debug.Log("Player out of range");
			//inRange = false;
		}
	}
	private void Shoot() {


			Debug.Log ("Shooting in range");
			GameObject shot = Instantiate(bulletPrefab, bulletSpawner.transform.position, Quaternion.identity) as GameObject;
			shot.transform.eulerAngles = this.transform.eulerAngles;
			shooterfireSource.clip = shooterfire;
			shooterfireSource.Play ();
			anim.SetBool("Sighted", true);
			//shooterfireSource.clip = shooterfire;
			//shooterfireSource.Play ();s
	}

	IEnumerator Damage()
	{
		enHealth--;
		shooterdamageSource.clip = shooterdamage;
		shooterdamageSource.Play ();
		GameObject explosion1 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
		GameObject explosion2 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
		Destroy(explosion1, 1f);
		Destroy(explosion2, 1f);
		Color maincolor = GetComponent<SpriteRenderer> ().color;
		GetComponent<SpriteRenderer>().color = colors[0];
		maincolor.a = 1;
		yield return new WaitForSeconds(.5f);
		GetComponent<SpriteRenderer> ().color = colors [1];
		maincolor.a = 1;
	}

	IEnumerator OnDeath()
	{
		Debug.Log ("ondeath played");
		GetComponent<BoxCollider2D>().enabled = false;
		//target = GameObject.Find("Pit").transform;
		anim.SetBool("Sighted", false);
		//InvokeRepeating("Shoot", 1f, 0);
		//inRange = false;
		GameObject explosion1 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
		//GameObject explosion2 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
		Destroy(explosion1, 1f);
		//Destroy(explosion2, 1f);
		//Play enemy death sound and then destroy
		shooterdeathSource.clip = shooterdeath;
		shooterdeathSource.Play ();
		//anim.SetBool("Dead", true);
		//inRange = false;

		yield return new WaitForSeconds(1.5f);
		//Destroy(this.gameObject); 

	} 
}

