﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

	public int health;
	public float speed; 
    private float dazedTime;
    public float startDazedTime;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(dazedTime <= 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }

		transform.Translate(Vector2.left *speed * Time.deltaTime);
	}

	public void TakeDamage(int damage)
	{
        dazedTime = startDazedTime;
		health -= damage;
		Debug.Log("Damage TAKEN!");
	}
}

