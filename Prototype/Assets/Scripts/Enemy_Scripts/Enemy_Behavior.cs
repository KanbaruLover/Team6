using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float timeBtwDamage;
    public float startTimeBtwDamage;
    public float attackRange;

    public Transform player;
    public Transform attackPos;
    public LayerMask whatIsPlayer;

    public int damage;

    bool isInRange = false; //Do not want player to randomly take damage
    




    // Use this for initialization
    void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;

            isInRange = true;
            timeBtwDamage += Time.deltaTime;
        }

        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        //Attack Player
        if (isInRange == true && timeBtwDamage >= 3)
        {
            //then they can attack
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Player_Controller>().health -= damage;
                }
            Debug.Log("PLAYER TOOK DAMAGE!!");

            timeBtwDamage = 0;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }

}
