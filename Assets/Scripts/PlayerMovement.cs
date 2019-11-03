using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour {

	public float moveSpeed,jumpforce;

	private Rigidbody myRigidBody;
	private Transform t;
	private float highscore;

	private HealthBar hb;
	private float healdamage=2f;

	public bool dead = false;
	public DeathMenu deathmenu;

	public AudioSource jumpSound,deadSound,eatFruitSound,eatBasketSound;

	public bool playerDead = false;

	// Use this for initialization
	void Start () {
		hb = FindObjectOfType<HealthBar> ();
		myRigidBody = GetComponent<Rigidbody> ();
		t = GetComponent<Transform> ();
		}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<HealthBar> ().hitpoint == 0 || dead || playerDead) {
			playerDead = true;
			deathmenu.ToggleEndMenu (GetComponent<Timer>().timer);
			return;
			}
		//look on spike death too.
		//IncreaseSpeed ();
		if (GetComponent<HealthBar> ().hitpoint >= 50)
			moveSpeed = 40f;
		else if (GetComponent<HealthBar> ().hitpoint < 50) {
			moveSpeed = 30f;
		}

		myRigidBody.velocity = new Vector3 (0,myRigidBody.velocity.y,moveSpeed);

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			jumpSound.Play ();
			myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x,jumpforce);
			myRigidBody.AddForce (-t.up*300);
		}
		//moveSpeed = 30.0f;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "FruitBasket") {
			//Debug.Log ("Increase speed");
			//IncreaseSpeed (20.0f);
			eatBasketSound.Play();
			GetComponent<HealthBar> ().hitpoint = 150f;
			other.gameObject.SetActive (false);
		}
		if (other.tag == "Spike") {
			deathmenu.ToggleEndMenu (GetComponent<Timer>().timer);
			dead = true;
			deadSound.Play ();
			return;
		}
		if (other.tag == "Fruit") {
			eatFruitSound.Play ();
			hb.HealDamage (healdamage);
			other.gameObject.SetActive (false);
		}
	}


	void IncreaseSpeed(float speed=0.0f)
	{
		moveSpeed = moveSpeed + speed;
	}
}
