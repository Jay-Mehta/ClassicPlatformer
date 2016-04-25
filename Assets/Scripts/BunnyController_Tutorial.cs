using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BunnyController_Tutorial : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator myAnim;
	private Collider2D collider;
	private float startTime;
	private int jumpsLeft = 2;
	private int EnemyLayer;
	private float bunnyHurtTime = -1;
	private float someTime;
	public AudioSource jumpSfx;
	public AudioSource deathSfx;
	public AudioSource bGMusic;
	public float jumpForce = 500f;
	public bool jumpFirstText = false;
	public bool jumpSecondText = false;
	public bool hurtFirstText = false;
	public bool hurtSecondText = false;
	public bool hurtThirdText = false;
	public GameObject jumpFirst;
	public GameObject jumpSecond;




	// Use this for initialization
	void Start () 
	{
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		collider = GetComponent<Collider2D> ();
		startTime = Time.time;
		jumpFirstText= false;
		jumpSecondText = false;
		hurtFirstText = false;
		hurtSecondText = false;
		hurtThirdText = false;

	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.Escape)) 
		{
			Application.LoadLevel ("Title");
		}
			
		if (!jumpFirstText && (Time.time > 3)) {
			jumpFirstText = true;
			jumpFirst.active = true;

		}
		if (((Input.GetButtonDown ("Jump")) || (Input.GetButtonDown ("Fire1"))) && jumpsLeft > 0) {
			if (myRigidBody.velocity.y > 0) {
				myRigidBody.velocity = Vector2.zero;
				myRigidBody.AddForce (transform.up * jumpForce * 0.75f);
			} else {
				myRigidBody.velocity = Vector2.zero;
				myRigidBody.AddForce (transform.up * jumpForce);
			}
			jumpFirst.active = false;
			if (!jumpSecondText && jumpFirstText) {
				jumpSecondText = true;
				jumpSecond.active = true;
				someTime = Time.time;
			}
			if (jumpSecond.active && (someTime +2 < Time.time)) {
				Debug.Log ("in 3");
				jumpSecond.active = false;
			}
			jumpsLeft--;
			jumpSfx.Play ();
		}

			
//		if (bunnyHurtTime == -1) 
//		{
//			if (((Input.GetButtonDown ("Jump"))||(Input.GetButtonDown ("Fire1")))&& jumpsLeft > 0) 
//			{
//
//
//				if (myRigidBody.velocity.y > 0) 
//				{
//					myRigidBody.velocity = Vector2.zero;
//					myRigidBody.AddForce (transform.up * jumpForce * 0.75f);
//				} 
//				else 
//				{
//					myRigidBody.velocity = Vector2.zero;
//					myRigidBody.AddForce (transform.up * jumpForce);
//				}
//				jumpsLeft--;
//				jumpSfx.Play ();
//			}
//
//			myAnim.SetFloat ("vVelocity", Mathf.Abs (myRigidBody.velocity.y));
//			 
//		} 
//		else 
//		{
//			if (Time.time > bunnyHurtTime + 2) 
//			{
//				Application.LoadLevel (Application.loadedLevel);
//			}
//		}


	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag=="Enemy")
		{
			foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>()) 
			{

				moveLefter.enabled = false;
			}
			foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>()) 
			{

				spawner.enabled = false;
			}

			bunnyHurtTime = Time.time;
			myAnim.SetBool ("bunnyHurt", true);

			myRigidBody.velocity = Vector2.zero;
			myRigidBody.AddForce(transform.up * jumpForce);

			collider.enabled = false;

			deathSfx.Play ();
			bGMusic.Stop ();

		}
		else if (other.gameObject.tag=="Platform")
		{
			jumpsLeft = 2;
		}
	}
}
