using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player_Controller : MonoBehaviour {

    public Animator witch;
    public Animator wizard;
	public string winscene;

	public GameObject player;
	private SceneFadeInOut fadescript;
	public Image fader;
	//Cam
	public float groundY;
	public bool hitGround;
	public bool hitMoving;
	public bool killboxed;

    public float maxSpeed = 10f;
    public float baseSpeed = 10f;
    public float jumpForce = 300f;
    public float baseJump = 300f;
    private bool facingRight = true;

    public bool paused;

    private Rigidbody2D body2D;
    private Animator anim;
    private BoxCollider2D boxcollider2D;

    private bool grounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public int curHealth;
    public int maxHealth = 3;
	public int nextlevel;

    private bool canBeHit = true;
    private int hitCount = 0;

	[Header("Audio")]
	private AudioSource[] allAudioSources;
	private AudioSource jumpSource;
	private AudioSource damageSource;
	private AudioSource deathSource;
	public AudioClip jumpsound;
	public AudioClip damagesound;
	public AudioClip deathsound;


	private GameObject camcam;
	public bool winner;
	public Color[] colors;
	public Text text;

    void Awake()
    {

		LevelManager.setLastLevel (SceneManager.GetActiveScene().name);
		Debug.Log (SceneManager.GetActiveScene().name);
		//LevelManager.setLastLevel (Application.loadedLevelName);
        body2D = GetComponent<Rigidbody2D>();
        boxcollider2D = GetComponent<BoxCollider2D>();


        /*if(MenuManager.characterSelected == 0)
        {
            anim = witch;
        }
        else if (MenuManager.characterSelected == 1)
        {
            anim = wizard;
            witch.runtimeAnimatorController = Resources.Load("WizardController") as RuntimeAnimatorController;
        } */

        anim = GetComponent<Animator>(); 
		StartCoroutine (LevelText ());
    }

	// Use this for initialization
	void Start ()
    {
		//GetComponent<Rigidbody2D> ().gravityScale = .5f;
		camcam = GameObject.Find ("Main_Camera(1)");
		//body2D.transform.position = CheckPoint.GetActiveCheckPointPosition();
        curHealth = maxHealth;
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		jumpSource = allAudioSources [0];
		damageSource = allAudioSources [1];
		deathSource = allAudioSources [2];

		maxSpeed = baseSpeed;
		jumpForce = baseJump;
        //baseJump = 0;

	}

	void FixedUpdate () {

		if (winner && SceneManager.GetActiveScene ().name != "Level3") {
			//body2D.AddForce (new Vector2 (0, jumpForce));
			//StartCoroutine(WinLook());
			body2D.velocity = new Vector2 (1, 0);
			//Win ();
		}

		if (winner && SceneManager.GetActiveScene ().name == "Level3") {
			body2D.velocity = new Vector2 (0, 2.5f);
		}

        //uses the groundcheck transform to find whether we are ON THE GROUND. Returns true or false.
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //Using Axis to move Horizontal, should work on controller.
        float move = Input.GetAxis("Horizontal");

        //makes the animator change to the movement animation
        if (grounded)
        {
            anim.SetBool("Jumping", false);
            anim.SetFloat("Speed", Mathf.Abs(move));
        } else {
            anim.SetFloat("Speed", 0);
            //anim.SetBool("Grounded", false);
        }

        if(Input.GetAxisRaw("RightJoyHorizontal") > 0.1 || Input.GetAxisRaw("RightJoyHorizontal") < -0.1 ||
            Input.GetAxisRaw("RightJoyVertical") > 0.1 || Input.GetAxisRaw("RightJoyVertical") < -0.1 && grounded)
        {
            //anim.SetBool("Casting", true);
        }
        else
        {
            //anim.SetBool("Casting", false);
        }

        //moves the player left or right based on button press.
		if (!winner) {
			body2D.velocity = new Vector2 (move * maxSpeed, body2D.velocity.y);
		}



        if(move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
	}

    //In the update function it starts off with the Jump and goes into the players health.
    void Update()
    {

        /*if (Input.GetButtonDown("Pause") && paused == false)
        {
            StartCoroutine(Pause());
        }

        else if(Input.GetButtonDown("Pause") && paused == true)
        {
            StopCoroutine(Pause());
            StartCoroutine(Resume());
        } */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Not a hard reset, but a reset none the less.
            body2D.transform.position = CheckPoint.GetActiveCheckPointPosition();
            curHealth = maxHealth;
            maxSpeed = baseSpeed;
            jumpForce = baseJump;
        } 

		if(Input.GetButtonDown("Fire2"))
		{
			maxSpeed = 4;
			baseJump = 550;
			jumpForce = 550;
			GetComponent<Rigidbody2D> ().gravityScale = 3f;
		}
        //Currently Jump is just the space button for testing purposes, we will change this!
        if(grounded && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Ground", true);
            anim.SetBool("Jumping", true);
            body2D.AddForce(new Vector2(0, jumpForce));
			//Jump Audio
			jumpSource.clip = jumpsound;
			jumpSource.Play ();
        }
        else
        {
            anim.SetBool("Ground", false);
        }

        if (!grounded)
        {
            anim.SetBool("Ground", true);
            anim.SetBool("Jumping", true);
        }
        else
        {
            anim.SetBool("Ground", false);
        }
        //Checks whether you have Health.
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if(curHealth <= 0)
        {

            Die();
        }
			
    }

    void Flip()
    {
        //acquires local scale and flipping it to make the character face properly.
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Die()
    {
        StartCoroutine(Death());
		
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        //if an enemy bullet touches player, health decreases and bullet destroys
		if (col.gameObject.tag == "Deadly")
        {
            if(canBeHit == true)
            {
                //Take damage audio
                canBeHit = false;
                damageSource.clip = damagesound;
                damageSource.Play();
                //curHealth--;
                StartCoroutine(Damage());
                StartCoroutine(Hit());

                //Destroy(col.gameObject);
            }

        }
        if (col.gameObject.tag == "Killbox")
        {
			//killboxed = true;
			//Debug.Log ("killbox initiating fadescript");
			//fader.GetComponent<SceneFadeInOut> ().sceneEnding = true;
			//fadescript.EndScene ();
			//Die();
        }

		if (col.gameObject.tag == "Winbox" && winner)
		{
			//killboxed = true;
			//Debug.Log ("killbox initiating fadescript");
			Debug.Log("should be winning");
            //Debug.Log (fader.GetComponent<SceneFadeInOut> ().levelint);	
            fader.GetComponent<SceneFadeInOut> ().scenery = winscene;
			//Debug.Log (fader.GetComponent<SceneFadeInOut> ().levelint);
			fader.GetComponent<SceneFadeInOut> ().sceneEnding = true;
            //fadescript.EndScene ();
            //Win();
        }
		if (col.gameObject.tag == "Moving") {
			hitGround = false;
			hitMoving = true;
			transform.parent = col.transform;
		}

		if (col.gameObject.tag == "MovingStrictCam") {
			hitGround = true;
			hitMoving = false;
			transform.parent = col.transform;
		}




    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "Deadly" || col.gameObject.tag == "BulletHold")
		{
            if(canBeHit == true)
            {
                //Take damage audio
                canBeHit = false;
                damageSource.clip = damagesound;
                damageSource.Play();
                //curHealth--;
                StartCoroutine(Damage());
                StartCoroutine(Hit());
            }
            
            
        }

		if (col.gameObject.tag == "Ground") {
			groundY = col.transform.position.y;
			hitGround = true;
			hitMoving = false;

		}

		if (col.gameObject.tag == "TarPit") {
			maxSpeed = 1;
			jumpForce = 300;
			//curHealth = curHealth - 1;
			//StartCoroutine(TarDamage());
			//StartCoroutine(Hit());

		}


	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "TarPit") {
			maxSpeed = 3;
			jumpForce = 550;
		}

        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Deadly" || col.gameObject.tag == "BulletHold")
        {
            if(canBeHit == false)
            {
                //Take damage audio
                canBeHit = true;
                damageSource.clip = damagesound;
                damageSource.Play();
                //curHealth--;
                StartCoroutine(Damage());
                StartCoroutine(Hit());

            }

        }
    }
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Moving" || col.gameObject.tag == "MovingStrictCam") {
			transform.parent = null;
		}
        if (col.gameObject.tag == "Deadly")
        {
            if(canBeHit == false)
            {
                canBeHit = true;
            }
        }

    }

    IEnumerator Damage()
    {
        //yield return new WaitForSeconds(.5f);
        if(curHealth > 0)
        {
            curHealth--;
            anim.SetBool("Hit", true);
        }
        else if(curHealth <= 0)
        {
            anim.SetBool("Death", true);
        }
        yield return new WaitForSeconds(1f);
        anim.SetBool("Hit", false);
        canBeHit = true;
    }


	IEnumerator TarDamage()
	{
		
		yield return new WaitForSeconds(3f);
		//curHealth--;
		//StartCoroutine(Hit());
	}

    IEnumerator Death()
    {
        //Death Audio
        deathSource.clip = deathsound;
        deathSource.Play();
        damageSource.Stop();

        boxcollider2D.enabled = false;

        maxSpeed = 0f;
        jumpForce = 0f;
        anim.SetBool("Dead", true);

        yield return new WaitForSeconds(1f);
        deathSource.Stop();
        //fader.GetComponent<SceneFadeInOut> ().levelint = SceneManager.GetActiveScene ().buildIndex;
        fader.GetComponent<SceneFadeInOut> ().sceneEnding = true;

		yield return new WaitForSeconds(1f); //2f //1.1f

        //deathSource.Stop();

        //This needs to be updated in case they run out of lives?
        anim.SetBool("Dead", false);
        //body2D.transform.position = CheckPoint.GetActiveCheckPointPosition();
        curHealth = maxHealth;
        maxSpeed = baseSpeed;
        jumpForce = baseJump;
    }

    IEnumerator Hit()
    {   if(curHealth > 0)
        {
            anim.SetBool("Hit", true);
			Color maincolor = GetComponent<SpriteRenderer> ().color;
			GetComponent<SpriteRenderer>().color = colors[0];
			maincolor.a = 1;
            yield return new WaitForSeconds(.4f);
            anim.SetBool("Hit", false);
			GetComponent<SpriteRenderer> ().color = colors [1];
			maincolor.a = 1;
        }
      
    }

	IEnumerator WinLook()
	{   if(curHealth > 0)
		{
			Flip ();
			yield return new WaitForSeconds(.8f);
			Flip ();
		}

	}

	IEnumerator Win()
	{
		Debug.Log ("winning");
		maxSpeed = 0f;
		jumpForce = 0f;
		//anim.SetBool("Dead", true);
		fader.GetComponent<SceneFadeInOut> ().scenery = winscene;
		//fader.GetComponent<SceneFadeInOut> ().sceneEnding = true;
		yield return new WaitForSeconds(5f);
	}

	IEnumerator LevelText()
	{
		yield return new WaitForSeconds(1.5f);
		text.CrossFadeAlpha(0.0f, 1.5f, false);
	}


    IEnumerator Pause()
    {
        paused = true;
        //player.GetComponent<Player_Controller>().enabled = false;
        player.GetComponent<ShieldPulse>().enabled = false;
        player.GetComponent<PulseGenerator>().enabled = false;

        yield return new WaitForSeconds(.025f);
        //counter = 0;
        //paused = false;
        Time.timeScale = 0;

    }

    IEnumerator Resume()
    {
        paused = true;
        //player.GetComponent<Player_Controller>().enabled = false;
        player.GetComponent<ShieldPulse>().enabled = true;
        player.GetComponent<PulseGenerator>().enabled = true;

        yield return new WaitForSeconds(.025f);
        //counter = 0;
        //paused = false;
        Time.timeScale = 1;

    }
}
