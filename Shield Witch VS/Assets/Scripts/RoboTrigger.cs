using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class RoboTrigger : MonoBehaviour {

	public GameObject[] enemies;
	//Audio
	private AudioSource triggerSource;
	public AudioClip triggersound;
	private Enemy script1;
	private Enemy script2;
	void Start (){
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		triggerSource = allAudioSources [0];
	}

	void OnTriggerEnter2D(Collider2D hit){

		if (hit.CompareTag("Player"))
		{

			script1 = enemies [0].GetComponent<Enemy> ();
			script2 = enemies [1].GetComponent<Enemy> ();
			script1.enabled = true;
			script1.chasing = true;
			script2.enabled = true;
			script2.chasing = true;
			enemies[0].GetComponent<BoxCollider2D>().enabled = true;
			enemies[1].GetComponent<BoxCollider2D>().enabled = true;
			StartCoroutine (ShutDown ());
			triggerSource.clip = triggersound;
			triggerSource.Play ();


		}
	}

	IEnumerator ShutDown()
	{
		yield return new WaitForSeconds (8f);
		script1.chasing = false;
		script2.chasing = false;
		enemies[0].GetComponent<BoxCollider2D>().enabled = false;
		enemies[1].GetComponent<BoxCollider2D>().enabled = false;
		//script1.enabled = false;

	}
}
       
