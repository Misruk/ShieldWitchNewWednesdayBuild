using UnityEngine;
using System.Collections;

public class FallingFruit : MonoBehaviour {

    private Rigidbody2D rb;

    public float fallDelay;

	private AudioSource[] allAudioSources;
	private AudioSource rockSource;
	public AudioClip rocksound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		rockSource = allAudioSources [0];
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Deadly" || col.gameObject.tag == "Enemy")
        {
            StartCoroutine(Fall());
        }

        if(col.gameObject.tag == "Killbox")
        {
            rb.isKinematic = true;
        }

		if (col.gameObject.tag == "TarPit") {
			rb.isKinematic = true;
			rockSource.clip = rocksound;
			rockSource.Play ();
		}
    }


    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;

        yield return 0;
    }
}
