using UnityEngine;
using System.Collections;

public class expand : MonoBehaviour {

    public float size;
    public float deathTime;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(size, size, 0f);

        Destroy(gameObject, deathTime);
    }
}
