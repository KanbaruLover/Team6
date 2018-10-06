using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller: MonoBehaviour {

	public float speed;		//Floating point variable to store the player's movement speed.
	
	private Rigidbody2D rb2d;   //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Vector2 moveVelocity;
		
	// Use this for initialization
	void Start () 
	{

		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
	}

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);
    }

}