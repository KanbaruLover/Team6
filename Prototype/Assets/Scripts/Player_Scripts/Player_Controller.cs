﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller: MonoBehaviour {

	public float speed;		//Floating point variable to store the player's movement speed.
    public int health;
	
	private Rigidbody2D rb2d;   //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Vector2 moveVelocity;
    private int minY = -3;
    private int maxY = 1;


    // Use this for initialization
    void Start () 
	{

		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
    void Update () 
    {
        Mathf.Clamp(transform.position.y, minY, maxY);
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;


        if(health <= 0)
        {

            Destroy(gameObject);

            SceneManager.LoadScene("Level_1");


        }


	}

    private void FixedUpdate()
    {

        rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);
    }


     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("sushi"))
        {
            //... then set the other object we just collided with to inactive.
            other.gameObject.SetActive(false);

            health += 13;

        }

    }


}