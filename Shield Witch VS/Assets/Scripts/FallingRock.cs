using UnityEngine;
using System.Collections;

public class FallingRock : MonoBehaviour {

    private Rigidbody2D rb;

    public float fallDelay;

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
    }


    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
        GetComponentInChildren<Collider2D>().isTrigger = true;

        yield return 0;
    }
}
