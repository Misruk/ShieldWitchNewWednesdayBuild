using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Notes : MonoBehaviour {

	public Image noteImage;
	public Image noteButtonImage;
	public Text noteHUD;
	public GameObject noteImage1;
	public GameObject noteButtonImage1;
	public bool touchingNote;
	public int counter = 0;
	public bool ready = false;

	[Header("Audio")]
	private AudioSource[] allAudioSources;
	private AudioSource openSource;
	private AudioSource closeSource;
	private AudioSource contactSource;
	public AudioClip openNote;
	public AudioClip closeNote;
	public AudioClip contactNote;

	// Use this for initialization
	void Start () {
		noteImage1.SetActive (false);
		noteButtonImage1.SetActive (false);
		noteImage.enabled = true;
		noteButtonImage.enabled = true;
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		openSource = allAudioSources [0];
		closeSource = allAudioSources [1];
		contactSource = allAudioSources [2];
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.gameObject.name == "Player_Test") {
			touchingNote = true;
			//Touch note audio
			contactSource.clip = contactNote;
			contactSource.Play ();
			//noteButtonImage.enabled = true;
			//noteHUD.text = "Press Up to Read";

			Debug.Log ("Hit note.");

			//Destroy (caseHUD);
			//Destroy (jewelImage);
			//Destroy (objectiveHUD);
		} 

	}

	void OnTriggerExit2D(Collider2D col)
	{
		touchingNote = false;
	}

	// Update is called once per frame
	void Update () {
		if (!ready && touchingNote && Input.GetButtonDown ("Y")) {
			//Audio opening
			noteImage1.SetActive (true);
			//StartCoroutine(Wait());
			openSource.clip = openNote;
			openSource.Play ();
			counter++;

			StartCoroutine (Wait ());
			//noteHUD.text = "A to Close";

			//Instantiate (noteImage);
			//noteImage.enabled = true;

			//noteButtonImage.enabled = true;
		}
		if (/*Time.timeScale == 0 && */ready && Input.GetButtonDown("Y")) {
			//Audio closing note
			Time.timeScale = 1;
			//noteImage.enabled = false;
			ready = false;
			noteImage1.SetActive (false);
			noteButtonImage1.SetActive (false);
			closeSource.clip = closeNote;
			closeSource.Play ();
			//StartCoroutine(Wait());


			//noteHUD.text = "A to Read";

			//Destroy (noteImage);
		}
		if (touchingNote == false) {
			//noteHUD.text = "";
			//noteButtonImage.enabled = true;
			noteButtonImage1.SetActive (false);
			noteImage1.SetActive (false);
			//Destroy (noteImage);
		}
		if (touchingNote == true) {
			//noteHUD.text = "B to Read";
			//noteImage.enabled = false;
			//noteButtonImage.enabled = true;
			noteButtonImage1.SetActive (true);
			//Destroy (noteImage);
		}
	}

	IEnumerator Wait()
	{
		ready = false;
		yield return new WaitForSeconds (.025f);
		counter = 0;
		ready = true;
		Time.timeScale = 0;

	}
}
