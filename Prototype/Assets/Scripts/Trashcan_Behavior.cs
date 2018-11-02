using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan_Behavior : MonoBehaviour 
{

    public int health;
    private bool taskIsRunning = true; // set to true when you start the task

    private int number;


	// Use this for initialization
	void Start () 
    {

    }
	
	void Update()
    {
        if (health <= 0 && taskIsRunning == true)
        {
            number = Random.Range(1, 15);
            Debug.Log(number);

            if (number >= 10)
            {
                //sushi (health item)
            }

            if (number < 10 && number >= 5)
            {
                //slushie (energy item)
            }

            if (number < 5)
            {
                //no item
            }

            taskIsRunning = false;
        }

    }

    public void TakeLightDamage(int light_damage)
    {
        health -= light_damage;
        Debug.Log("Light Damage Taken!");
    }

    public void TakeHeavyDamage(int heavy_damage)
    {
        health -= heavy_damage;
        Debug.Log("Heavy Damage Taken!");
    }
}
