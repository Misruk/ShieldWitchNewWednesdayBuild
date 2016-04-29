using UnityEngine;
using System.Collections;

public class FallingRock : MonoBehaviour {

    private Rigidbody2D rb;
	public bool grounded;
    public float fallDelay;
	private GameObject bridge;

	private AudioSource[] allAudioSources;
	private AudioSource rockSource;
	public AudioClip rocksound;
	private AudioSource bridgeSource;
	public AudioClip bridgesound;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		rockSource = allAudioSources [0];
		bridgeSource = allAudioSources [1];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ShieldPulse") 
        {
            StartCoroutine(Fall());
        }

		if (col.gameObject.tag == "PuzzleGround") {
			grounded = true;
			bridge = GameObject.Find ("Bridge");
			bridge.AddComponent<MoveBridge> ();
			bridge.GetComponent<MoveBridge> ().max = -1.62f;
			bridge.GetComponent<MoveBridge> ().maxy = -4.526108f;
			bridge.GetComponent<MoveBridge> ().rate = 0.5f;
			bridgeSource.clip = bridgesound;
			bridgeSource.Play ();
		}
    }



    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
		rockSource.clip = rocksound;
		rockSource.Play ();
        rb.isKinematic = false;
        GetComponentInChildren<Collider2D>().isTrigger = true;

        yield return 0;
    }
}
