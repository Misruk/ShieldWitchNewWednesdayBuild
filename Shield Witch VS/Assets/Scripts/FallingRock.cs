using UnityEngine;
using System.Collections;

public class FallingRock : MonoBehaviour {

    private Rigidbody2D rb;
	public bool grounded;
    public float fallDelay;
	private GameObject bridge;
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
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
		}
    }



    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
        GetComponentInChildren<Collider2D>().isTrigger = true;

        yield return 0;
    }
}
