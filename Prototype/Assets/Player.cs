using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;						//Floating point variable to store the player's movement speed.
	
	private Rigidbody2D rb2d;				//Store a reference to the Rigidbody2D component required to use 2D Physics.
	private float standard_punch_player; 	//Will contain damage amount of standard punch for the player
	private float strong_punch_player;		//Will contain damage amount of strong punch for the player	
	// Use this for initialization
	void Start () 
	{
		//Initilize standard punch player
		standard_punch_player = 1;
		
		//Initilize strong punch player
		strong_punch_player = 4; 

		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement * speed);
	}

		//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "Enemy", if it is...
		if (other.gameObject.CompareTag ("Enemy")) 
		{

			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);

		}
	}
}
