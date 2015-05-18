using UnityEngine;
using System.Collections;

public class EnemyMovementCollider2 : MonoBehaviour 
{
	//collider that detects if the player is in range
	//gameobjects
	GameObject player;
	EnemyAttack enemyAttack;
	
	//vars
	public bool triggered;	
	
	
	void Start() 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		enemyAttack = gameObject.transform.parent.GetComponent<EnemyAttack>();
	}	
	
	
	void OnTriggerEnter(Collider co)
	{	
		if(co.gameObject == player)
		{
			enemyAttack.playerInRange = true;
			triggered = true;
			
		}
	}
	
	void OnTriggerExit(Collider co)
	{	
		if(co.gameObject == player)
		{
			enemyAttack.playerInRange = false;
			triggered = false;
			
		}
	}
}
