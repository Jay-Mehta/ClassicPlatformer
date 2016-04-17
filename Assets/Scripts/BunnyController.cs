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
		if (bunnyHurtTime == -1) 
		{
			if (Input.GetButtonDown ("Jump")) 
			{
				myRigidBody.AddForce (transform.up * jumpForce);
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
		}
	}
}
