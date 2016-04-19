using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BunnyController : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator myAnim;
	private Collider2D collider;
	public float jumpForce = 500f;
	private int EnemyLayer;
	private float bunnyHurtTime = -1;
	public Text scoreText;
	private float startTime;
	private int jumpsLeft = 2;
	public AudioSource jumpSfx;
	public AudioSource deathSfx;
	public AudioSource bGMusic;



	// Use this for initialization
	void Start () 
	{
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		collider = GetComponent<Collider2D> ();
		startTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.Escape)) 
		{
			Application.LoadLevel ("Title");
		}

		if (bunnyHurtTime == -1) 
		{
			if ((Input.GetButtonDown ("Jump"))||(Input.GetButtonDown ("Fire1"))&& jumpsLeft > 0) 
			{
				

				if (myRigidBody.velocity.y > 0) 
				{
					myRigidBody.velocity = Vector2.zero;
					myRigidBody.AddForce (transform.up * jumpForce * 0.75f);
				} 
				else 
				{
					myRigidBody.velocity = Vector2.zero;
					myRigidBody.AddForce (transform.up * jumpForce);
					jumpsLeft--;
					jumpSfx.Play ();
				}
			}

			myAnim.SetFloat ("vVelocity", Mathf.Abs (myRigidBody.velocity.y));

			scoreText.text = ((Time.time - startTime) * 10).ToString ("0");
		} 
		else 
		{
			if (Time.time > bunnyHurtTime + 2) 
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
				

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
