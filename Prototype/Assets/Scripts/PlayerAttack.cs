using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{	
	private float timeBtwAttack;
	
	public float startTimeBtwAttack;
	public Transform attackPos;
	public float attackRange; 
	public LayerMask whatIsEnemies;
    public float attackRangeX;
    public float attackRangeY;
	public int damage; 
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(timeBtwAttack <= 0)
		{
			//then you can attack
			if(Input.GetKey(KeyCode.Space))
			{
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX,attackRangeY), 0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
				{
					enemiesToDamage[i].GetComponent<Enemy_Health>().TakeDamage(damage); 
				}
			}

			timeBtwAttack = startTimeBtwAttack;
		}
		else
		{
			timeBtwAttack -= Time.deltaTime;
		}
	}


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position,new Vector3(attackRangeX,attackRangeY,1));
	}
}
