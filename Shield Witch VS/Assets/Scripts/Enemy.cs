using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    private Vector3 euler;
    private Vector3 look;

    public float speed = 1;
    public GameObject target;
	public GameObject target2;
    public GameObject scorePrefab;
    public bool chasing = true;
	public Collider2D OutOfRange;

    private int points = 100;

    public GameObject[] explosions;

    private Animator anim;

    //Enemy Audio
    [Header("Audio")]
	private AudioSource[] allAudioSources;
	private AudioSource attackSource;
	private AudioSource stunSource;
	private AudioSource deathSource;

	public AudioClip attack;
	public AudioClip stun;
	public AudioClip death;

	public bool isdead = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
		chasing = false;
		if(MenuManager.characterSelected == 0)
		{
			Debug.Log("Camera locked onto Witch");
		} else if (MenuManager.characterSelected == 1)
		{
			target = target2;
		}
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		attackSource = allAudioSources [0];
		stunSource = allAudioSources [1];
		deathSource = allAudioSources [2];
		//GetComponent<Enemy> ().enabled = false;
        //chasing = false;
	}

    void FixedUpdate()
    {
        if (chasing)
        {
            euler = transform.eulerAngles;
            look = target.transform.position - this.transform.position;
            this.transform.position += look.normalized * speed * Time.deltaTime;
            euler.z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = euler;
			attackSource.clip = attack;
			attackSource.Play ();

            //Plays the animation for the robot to come alive.
            anim.SetBool("Activated", true);
        }
        else
        {
            //Plays deactivated animation
            anim.SetBool("Activated", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {


        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("Touched Player");
            //target.GetComponent<Player>().TakeDamage(1);
			StartCoroutine (OnHit ());
        }

		if (col.gameObject.name == "Bullet 1(Clone)") {
			Destroy (col.gameObject);
		}
			

    }



		
	void OnTriggerEnter2D(Collider2D col)
	{
		/*if (col.gameObject.tag == "Player")
		{
			chasing = true;
			Debug.Log ("sensed player");
		}*/

		if (col.gameObject.tag == "ShieldPulse") {
			Debug.Log ("Enemy Collided with shield pulse");
			//OnStun ();
			StartCoroutine (OnStun ());
		}

		if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "BulletHold" || col.gameObject.tag == "Deadly" || col.gameObject.tag == "Killbox")
		{
			//target.GetComponent<Rescue>().addScoreEnemy(100);
			//Destroy(this.gameObject);
			StartCoroutine (OnDeath ());
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			//chasing = false;
			Debug.Log (" player left");
		}

	}
	IEnumerator OnStun()
	{
		//Play enemy death sound and then destroy
		//chasing = false;
		chasing = false;
		stunSource.clip = stun;
		stunSource.Play ();
		Debug.Log ("Changed chasing to false");
		GetComponent<Collider2D>().enabled = false;
		yield return new WaitForSeconds(2.5f);  
		GetComponent<Collider2D>().enabled = true;
		chasing = true;
		//stunnedEnemy.GetComponent<EnemyShooter> ().enabled = true;

		//Destroy(this.gameObject); 
	}

	IEnumerator OnHit()
	{
		//Play enemy death sound and then destroy
		//chasing = false;
		chasing = false;
		GetComponent<Collider2D>().enabled = false;
		yield return new WaitForSeconds(1f); 
		GetComponent<Collider2D>().enabled = true;
		chasing = true;
		//stunnedEnemy.GetComponent<EnemyShooter> ().enabled = true;

		//Destroy(this.gameObject); 
	}



	IEnumerator OnDeath()
	{
        GetComponent<BoxCollider2D>().enabled = false;
		chasing = false;
		GetComponent<Rigidbody2D> ().gravityScale = 2;
        //Play enemy death sound and then destroy
		GameObject explosion1 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
		GameObject explosion2 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
		Destroy(explosion1, 1f);
		Destroy(explosion2, 1f);
		deathSource.clip = death;
		deathSource.Play ();
		transform.Rotate (Vector3.forward * -90);
		//chasing = false;
		yield return new WaitForSeconds(2f);       
        //Destroy(this.gameObject); 
		isdead = true;


	} 
    /*public void OnDeath()
    {
        //GameObject scoreShow = Instantiate(scorePrefab, this.transform.position, Quaternion.identity) as GameObject;
        //scoreShow.transform.parent = GameObject.Find("Canvas2").transform;
        //scoreShow.GetComponent<Text>().text = "" + points;
        Destroy(this.gameObject);      
    }*/
}
