using UnityEngine;
using System.Collections;


public class doorOpen : MonoBehaviour {

    //public float min;

    public float max;//end x position
    public float maxr;// angle of rotation
    public float maxy;//end y position
    public float maxz;//end z position
    public float rate;
    public bool inRange;
    public bool open;
    public bool clickable;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (inRange && clickable && Input.GetButtonDown("Fire1"))
        {
            open = true;
        }

        if (open)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, max, Time.deltaTime * rate), Mathf.Lerp(transform.position.y, maxy, Time.deltaTime * rate), Mathf.Lerp(transform.position.z, maxz, Time.deltaTime * rate));
            transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(transform.eulerAngles.y, maxr, Time.deltaTime * rate), 0);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
}
