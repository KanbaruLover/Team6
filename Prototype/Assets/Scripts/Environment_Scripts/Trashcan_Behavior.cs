using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan_Behavior : MonoBehaviour
{

    public int health;
    public GameObject item;
    private bool taskIsRunning = true; // set to true when you start the task

    private int number;


    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (health <= 0 && taskIsRunning == true)
        {
            number = Random.Range(1, 5);
            Debug.Log(number);

            if (number >= 3)
            {
                //sushi

                GameObject sushi = Instantiate(item, item.transform.position, Quaternion.identity) as GameObject;
                sushi.transform.position = new Vector2(8, -2);

            }

            else
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
